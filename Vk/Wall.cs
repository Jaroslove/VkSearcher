using System.Collections.Generic;

namespace Vk
{
    /// <summary>
    /// This class presents the wall of a user or a widget from vk site,
    /// we use it in case we got the result of searching
    /// </summary>
    public class Wall
    {
        /// <summary>
        /// the number of posts of the wall
        /// </summary>
        public int PostCount { get; }

        /// <summary>
        /// the number of searched posts of the wall
        /// </summary>
        public long SearchedPost { get; }

        /// <summary>
        /// searched posts, in case doesn't exist appropriate posts, the list is empty
        /// </summary>
        public IEnumerable<Post> Posts { get; }

        /// <summary>
        /// check if error exists
        /// </summary>
        public bool IsError { get; }

        /// <summary>
        /// true if canceled
        /// </summary>
        public bool IsCanceled { get; }

        /// <summary>
        /// if error exists, this field contains the name of the error
        /// </summary>
        public string TextOfError { get; }

        public Wall(int postCount, long searchedPost, IEnumerable<Post> posts, bool isError = false, string textOfError = null)
        {
            PostCount = postCount;

            SearchedPost = searchedPost;

            Posts = posts;

            IsError = isError;

            TextOfError = textOfError;
        }

        public Wall()
        {
            this.IsCanceled = true;
        }
    }
}
