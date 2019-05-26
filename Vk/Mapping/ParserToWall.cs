using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.Mapping
{
    class ParserToWall
    {
        public Wall Parse(IEnumerable<PostWithComment> input, int numberOfPost)
        {
            if (input == null || input.Count() == 0)
            {
                return new Wall(numberOfPost, 0, new List<Post>());
            }

            var posts = new List<Post>();

            foreach (var post in input)
            {
                var comment = post.Comments.Select(c =>
                new Comment(Helper.ConvertorDate.ConvertDateTimeFromUnix(c.date), c.text));

                posts.Add(new Post(Helper.ConvertorDate.ConvertDateTimeFromUnix(post.Post.date), post.Post.text, comment, comment.Count()));
            }

            return new Wall(numberOfPost, posts.Count, posts);
        }
    }
}
