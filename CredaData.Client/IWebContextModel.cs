using System.Net;

namespace CredaData.Client
{
    public interface IWebContextModel
    {
        string ApiBaseUrl { get; }
        string DeviceUniqueId { get; }
        string AuthApiKey { get; }
        CookieContainer CookieContainer { get; }
    }
}