using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vk.Post_;
using Vk.Request;
using Vk.Serializer;

namespace Vk.Searching
{
    class GetterPost : IGetter<RootObject> 
    {
        long idUser;

        string token;

        Serialyzer<RootObject> serialyzer;

        Requester requester;

        RootObject rootObject;

        RequsetBuilder requsetBuilder;

        public GetterPost(long idUser, string token, Serialyzer<RootObject> serialyzer, Requester requester)
        {
            this.idUser = idUser;

            this.serialyzer = serialyzer;

            this.requester = requester;

            this.token = token;

            requsetBuilder = new RequsetBuilder();
        }

        public async Task<RootObject> Get(CancellationToken cancellationTokens)
        {
            cancellationTokens.ThrowIfCancellationRequested();

            rootObject = await FirstRequest();

            await SecondarlyRequest();

            return rootObject;
        }

        async Task<RootObject> FirstRequest()
        {
            var responce = await requester.Request(requsetBuilder.GetPostOnWall(idUser, token));

            return serialyzer.Serialyz(responce);
        }

        async Task SecondarlyRequest()
        {
            int allPost = rootObject.response.count;
            int increament = 100;

            if (allPost <= increament)
            {
                return;
            }else
            {
                do
                {
                    var responce = await requester
                        .Request(requsetBuilder.GetPostOnWallWithOffset(idUser, token, increament));

                    var serResponce = serialyzer.Serialyz(responce);

                    rootObject.response.items.AddRange(serResponce.response.items);

                    increament += 100;
                } while (allPost >= increament);
            }
        }
    }
}
