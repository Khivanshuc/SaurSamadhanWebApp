using System.Net;

namespace CredaData.Client
{
    public class WebContextModel : IWebContextModel
    {
        public WebContextModel(string apiBaseUrl, string deviceUniqueId, string authApiKey, CookieContainer cookieContainer)
        {
            ApiBaseUrl = apiBaseUrl;
            DeviceUniqueId = deviceUniqueId;
            AuthApiKey = authApiKey;
            CookieContainer = cookieContainer;
        }

        public string ApiBaseUrl { get; }
        public string DeviceUniqueId { get; }
        public string AuthApiKey { get; }
        public CookieContainer CookieContainer { get; }
    }
}
