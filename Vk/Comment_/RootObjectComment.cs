using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.Comment_
{
    public class Thread
    {
        public int count { get; set; }
        public List<ItemComment> items { get; set; }
        public bool can_post { get; set; }
        public bool show_reply_button { get; set; }
        public bool groups_can_post { get; set; }
    }

    public class ItemComment
    {
        public int id { get; set; }
        public int from_id { get; set; }
        public int post_id { get; set; }
        public int owner_id { get; set; }
        public List<ItemComment> parents_stack { get; set; }
        public int date { get; set; }
        public string text { get; set; }
        public Thread thread { get; set; }
    }

    public class ResponseComment
    {
        public int count { get; set; }
        public List<ItemComment> items { get; set; }
        public int current_level_count { get; set; }
        public bool can_post { get; set; }
        public bool show_reply_button { get; set; }
        public bool groups_can_post { get; set; }
    }

    public class RootObjectComment
    {
        public ResponseComment response { get; set; }
    }
}
