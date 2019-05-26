using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.Serializer
{
    class Serialyzer<T> where T : class
    {
        public T Serialyz(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
