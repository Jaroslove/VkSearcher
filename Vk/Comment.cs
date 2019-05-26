using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk
{
    /// <summary>
    /// This class presents the single comment of post on the wall from vk site,
    /// we use it in case we got the result of searching of this post
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// the date when the comment was created
        /// </summary>
        public DateTime CreatedDate { get; }

        /// <summary>
        /// comments to this comment
        /// </summary>
        //public IEnumerable<Comment> Comments { get; }

        /// <summary>
        /// text of this comment
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// in case this comment contains the searched value
        /// </summary>
        //public bool IsContain { get; }

        public Comment(DateTime createdDate, string text)
        {
            CreatedDate = createdDate;

            //Comments = comments;

            Text = text;

            //IsContain = IsContain;
        }
    }
}
