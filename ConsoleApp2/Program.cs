using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var access_token = "8885660029ad9bea28e4e25bfc3ed17be68fb2db838c3dac70370a68e64a0d46bca3cb8b0a309d4bbfa62";

            var meId = 23686752; // use it copy/past
            var beglovId = 535438957;

            using (var client = new HttpClient())
            {
                //var uri = "https://oauth.vk.com/authorize?client_id=1" +
                //    "&display=page&redirect_uri=https://oauth.vk.com/blank&scope=friends&response_type=token&v=5.95";

                var uri = "https://api.vk.com/method/wall.get?owner_id=535438957&count=100&access_token=" + access_token + "&v=5.95";
                
                var uriComment = "https://api.vk.com/method/wall.getComments?owner_id=535438957&post_id=42832&count=10&sort=desc&preview_length=0&access_token=" + access_token + "&v=5.95";

                //id from comment to comment 42804
                var uriCommentsToComment = "https://api.vk.com/method/wall.getComments?owner_id=535438957&post_id=42492&count=10&sort=desc&comment_id=42840&preview_length=0&access_token=" + access_token + "&v=5.95";

                var response = client.GetAsync(uri).GetAwaiter().GetResult();


                Console.WriteLine(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());

                var info = JsonConvert.DeserializeObject<RootObject>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());


                var responceComment = client.GetAsync(uriComment).GetAwaiter().GetResult();
                var infoComment = JsonConvert.DeserializeObject<RootObjectComment>(responceComment.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                //Console.WriteLine(responceComment.Content.ReadAsStringAsync().GetAwaiter().GetResult());

                var commentsToComment = client.GetAsync(uriCommentsToComment).GetAwaiter().GetResult();

                //Console.WriteLine(commentsToComment.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                //var info = JsonConvert.DeserializeObject<RootObject>(commentsToComment.Content.ReadAsStringAsync().GetAwaiter().GetResult());
            }

            //DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            //DateTime date = start.AddSeconds(1299976348).ToLocalTime();
            //Console.WriteLine(date);
        }
    }



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



    public class Thread
    {
        public int count { get; set; }
        public List<object> items { get; set; }
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
