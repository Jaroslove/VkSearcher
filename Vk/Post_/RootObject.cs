using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.Post_
{
    public class Comments
    {
        public int count { get; set; }
    }

    public class Likes
    {
        public int count { get; set; }
    }

    public class Reposts
    {
        public int count { get; set; }
    }

    public class Link
    {
        public string url { get; set; }
        public string title { get; set; }
        public string caption { get; set; }
        public string description { get; set; }
        public bool is_favorite { get; set; }
    }

    public class Size
    {
        public string type { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Photo
    {
        public int id { get; set; }
        public int album_id { get; set; }
        public int owner_id { get; set; }
        public List<Size> sizes { get; set; }
        public string text { get; set; }
        public int date { get; set; }
        public int post_id { get; set; }
    }

    public class Attachment
    {
        public string type { get; set; }
        public Link link { get; set; }
        public Photo photo { get; set; }
    }

    public class Item
    {
        public int id { get; set; }
        public int from_id { get; set; }
        public int owner_id { get; set; }
        public int date { get; set; }
        public string post_type { get; set; }
        public string text { get; set; }
        public int reply_owner_id { get; set; }
        public int reply_post_id { get; set; }
        public int can_delete { get; set; }
        public int can_pin { get; set; }
        public bool can_archive { get; set; }
        public bool is_archived { get; set; }
        public Comments comments { get; set; }
        public Likes likes { get; set; }
        public Reposts reposts { get; set; }
        public bool is_favorite { get; set; }
        public List<Attachment> attachments { get; set; }
    }

    public class Response
    {
        public int count { get; set; }
        public List<Item> items { get; set; }
    }

    public class RootObject
    {
        public Response response { get; set; }
    }
}
