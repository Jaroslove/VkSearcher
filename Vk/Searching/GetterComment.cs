using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vk.Comment_;
using Vk.Request;
using Vk.Serializer;
using Thread = Vk.Comment_.Thread;

namespace Vk.Searching
{
    class GetterComment : IGetter<RootObjectComment>
    {
        long idUser;

        string token;

        long post_id;

        Serialyzer<RootObjectComment> serialyzer;

        //Serialyzer<Comment_.CommentToComment.RootObject> serialyzerToComment;
        Serialyzer<Comment_.CommentToComment.RootObject> serialyzerToComment;

        Requester requester;

        RootObjectComment rootObject;

        RequsetBuilder requsetBuilder;

        public GetterComment(long idUser, string token, long post_id, Serialyzer<RootObjectComment> serialyzer, Requester requester)
        {
            this.idUser = idUser;

            this.post_id = post_id;

            this.serialyzer = serialyzer;

            this.requester = requester;

            this.token = token;

            requsetBuilder = new RequsetBuilder();

            serialyzerToComment = new Serialyzer<Comment_.CommentToComment.RootObject>();
        }

        public async Task<RootObjectComment> Get(CancellationToken cancellationToken)
        {
            rootObject = await FirstRequest();

            cancellationToken.ThrowIfCancellationRequested();

            await SecondarlyRequest();

            await GetCommentsToComments();

            return rootObject;
        }

        async Task<RootObjectComment> FirstRequest()
        {
            var responce = await requester.Request(requsetBuilder.GetCommentsFromPost(idUser, post_id, token));

            return serialyzer.Serialyz(responce);
        }

        async Task SecondarlyRequest()
        {
            int increament = 100;

            if (rootObject?.response?.items?.Count == 0)
            {
                return;
            }
            else
            {
                do
                {
                    try
                    {
                        var responce = await requester
                            .Request(requsetBuilder.GetCommentsFromPostOffset(idUser, post_id, token, increament));

                        var serResponce = serialyzer.Serialyz(responce);

                        if (serResponce?.response?.items?.Count == 0)
                        {
                            return;
                        }

                        rootObject.response.items.AddRange(serResponce.response.items);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                    increament += 100;
                } while (true);
            }
        }

        async Task GetCommentsToComments()
        {
            try
            {
                foreach (var item in rootObject?.response?.items)
                {
                    await GetCommentsR(item);
                }

            }
            catch (Exception ex)
            {
                var s = ex;
            }
        }

        async Task GetCommentsR(ItemComment item)
        {
            var countComments = item?.thread?.count;

            if (countComments > 0)
            {
                var inc = 0;
                do
                {
                    Comment_.CommentToComment.RootObject serResponce = null;

                    var responce = "";

                    try
                    {
                        responce = await requester
                        .Request(requsetBuilder.GetCommentsToCommentOffset(idUser, post_id, item.id, token, inc));

                        serResponce = serialyzerToComment.Serialyz(responce);
                    }
                    catch (Exception)
                    {
                        serResponce = null;
                    }

                    if (serResponce != null)
                    {

                        foreach (var i in serResponce?.response?.items)
                        {
                            if (i != null)
                            {
                                var o = new ItemComment
                                {
                                    date = i.date,
                                    from_id = i.from_id,
                                    id = i.id,
                                    owner_id = i.owner_id,
                                    parents_stack = new List<ItemComment>(),
                                    post_id = i.post_id,
                                    text = i.text,
                                    thread = new Thread(),
                                };
                                await GetCommentsR(o);

                            }
                        }

                        var oo = serResponce?.response?.items?
                            .Where(i => i != null)
                            .Select(i =>
                            new ItemComment
                            {
                                date = i.date,
                                from_id = i.from_id,
                                id = i.id,
                                owner_id = i.owner_id,
                                parents_stack = new List<ItemComment>(),
                                post_id = i.post_id,
                                text = i.text,
                                thread = new Thread(),
                            })
                            .ToList();
                        if (oo != null)
                        {
                            item.thread.items.AddRange(oo);
                        }
                    }

                    inc += 100;

                } while (countComments >= inc);
            }
        }
    }
}
