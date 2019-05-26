using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk.Request
{
    class RequsetBuilder
    {
        const string API_VK = "https://api.vk.com/method";
        const string METHOD_GET_WALL = "/wall.get?";
        const string METHOD_GET_COMMENTS = "/wall.getComments?";
        const string OWNER_ID = "owner_id=";
        const string COUNT = "&count=";
        const string OFFSET = "&offset=";
        const string ACCESS_TOKEN = "&access_token=";
        const string POST_ID = "&post_id=";
        const string SORT = "&sort=desc";
        const string P_L = "&preview_length=0";
        const string COMMENT_ID = "&comment_id=";
        const string VERSION = "&v=5.95";        


        public string GetPostOnWall(long owner_id, string token, int count = 100)
        {
            return API_VK + METHOD_GET_WALL + OWNER_ID + owner_id + COUNT + count + ACCESS_TOKEN + token + VERSION;
        }

        public string GetPostOnWallWithOffset(long owner_id, string token, int offset, int count = 100)
        {
            return API_VK + METHOD_GET_WALL + OWNER_ID + owner_id + COUNT + count + OFFSET + offset + ACCESS_TOKEN + token + VERSION;
        }

        public string GetCommentsFromPost(long owner_id, long post_id, string token, int count = 100)
        {
            return API_VK + METHOD_GET_COMMENTS + OWNER_ID + owner_id + POST_ID + post_id
                + COUNT + count + SORT + P_L + ACCESS_TOKEN + token + VERSION;
        }

        public string GetCommentsFromPostOffset(long owner_id, long post_id, string token, int offset, int count = 100)
        {
            return API_VK + METHOD_GET_COMMENTS + OWNER_ID + owner_id + POST_ID + post_id + OFFSET + offset
                + COUNT + count + SORT + P_L + ACCESS_TOKEN + token + VERSION;
        }

        public string GetCommentsToComment(long owner_id, long post_id, long comment_id, string token, int count = 100)
        {
            return API_VK + METHOD_GET_COMMENTS + OWNER_ID + owner_id + POST_ID + post_id
                + COUNT + count + SORT + COMMENT_ID + comment_id
                + P_L + ACCESS_TOKEN + token + VERSION;
        }

        public string GetCommentsToCommentOffset(long owner_id, long post_id, long comment_id, string token, int offset, int count = 100)
        {
            return API_VK + METHOD_GET_COMMENTS + OWNER_ID + owner_id + POST_ID + post_id + OFFSET + offset 
                + COUNT + count + SORT + COMMENT_ID + comment_id
                + P_L + ACCESS_TOKEN + token + VERSION;
        }
    }
}
