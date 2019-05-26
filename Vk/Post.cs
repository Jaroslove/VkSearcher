using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk
{
    /// <summary>
    /// This class presents the single post on the wall from vk site,
    /// we use it in case we got the result of searching of this post
    /// </summary>
    public class Post
    {
        /// <summary>
        /// the date when the post was created
        /// </summary>
        public DateTime CreatedDate { get; }

        /// <summary>
        /// the text of this post
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// all comment to this post
        /// this field doesn't include comments which added to comments,
        /// count only comments exactly to this post
        /// </summary>
        public IEnumerable<Comment> Comments { get; }

        /// <summary>
        /// true if the text of Post contains the searched value
        /// </summary>
        //public bool IsPostContain { get; }

        /// <summary>
        /// true if the text of comments to this post or comments to comment of this post 
        /// contains the searched value
        /// </summary>
        //public bool IsCommentsContain { get; }

        /// <summary>
        /// the number of appropriate comments
        /// </summary>
        public long CountOfContainedComments { get; }

        public Post(DateTime createdDate, string text, IEnumerable<Comment> comments, long countOfConComment )
        {
            CreatedDate = createdDate;

            Text = text;

            Comments = comments;

            //IsPostContain = IsPostContain;

            //IsCommentsContain = isCommentsContain;

            CountOfContainedComments = countOfConComment;
        }
    }
}
