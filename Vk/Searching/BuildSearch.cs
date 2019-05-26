using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vk.Comment_;
using Vk.Mapping;
using Vk.Post_;
using Vk.Request;
using Vk.Serializer;

namespace Vk.Searching
{
    class BuildSearch
    {
        string token;
        long idUser;

        GetterPost getterPost;

        RootObject rootObject;

        Requester requester;

        public List<PostWithComment> Posts { get; set; }

        public BuildSearch(string token, long idUser)
        {
            this.token = token;
            this.idUser = idUser;

            requester = new Requester();
            Posts = new List<PostWithComment>();
        }

        public async Task<BuildSearch> GetGetterPost(CancellationToken cancellationToken)
        {
            getterPost = new GetterPost(idUser, token, new Serialyzer<RootObject>(), requester);
            rootObject = await getterPost.Get(cancellationToken);

            return this;
        }

        public async Task<BuildSearch> GetGetterComment(CancellationToken cancellationToken, IProgress<int> progress)
        {
            int result = 100;
            if (rootObject?.response?.count > 0)
            {
                var serialyzer = new Serialyzer<RootObjectComment>();

                int? total = rootObject?.response?.items?.Count;                

                if (total.HasValue)
                {
                    result = 0;
                }

                foreach (var post in rootObject.response.items)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    result++;

                    progress.Report(result/total.Value * 100);

                    var getComment = new GetterComment(idUser, token, post.id, serialyzer, requester);

                    var comment = await getComment.Get(cancellationToken);

                    Posts.Add(new PostWithComment { Post = post, Comments = comment?.response?.items });
                }
            }

            return this;
        }

        public IEnumerable<PostWithComment> Get()
        {
            return Posts;
        }
    }
}
