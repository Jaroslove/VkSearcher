namespace Vk
{
    /// <summary>
    /// use this class to set your token
    /// </summary>
    public class AccessToken
    {
        /// <summary>
        /// copy this field to your brower, then clik ok, and rediret to another page
        /// then copy value from access_token from address string browser
        /// </summary>
        public const string STRING_TO_GET_ACCESS_TOKEN 
            = "https://oauth.vk.com/authorize?client_id=1&display=page&redirect_uri=https://oauth.vk.com/blank&scope=friends&response_type=token&v=5.95";

        /// <summary>
        /// paste your token here 
        /// </summary>
        public string Token { get; set; }
    }
}