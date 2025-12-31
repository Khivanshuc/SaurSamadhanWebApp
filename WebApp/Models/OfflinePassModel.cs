using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("sms")]
    public class OfflinePassModel :IModel
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
    }
}

