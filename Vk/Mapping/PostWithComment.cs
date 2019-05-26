using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vk.Comment_;
using Vk.Post_;

namespace Vk.Mapping
{
    class PostWithComment
    {
        public IEnumerable<ItemComment> Comments = new List<ItemComment>();

        public Item Post = new Item();
    }
}
