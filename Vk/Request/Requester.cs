using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Vk.Request
{
    class Requester
    {
        public async Task<string> Request(string uri)
        {
            using (var client = new HttpClient())
            {
                var responce = await client.GetAsync(uri);

                return await responce.Content.ReadAsStringAsync();
            }
        }
    }
}
