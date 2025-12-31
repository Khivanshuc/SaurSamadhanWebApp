using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("grievance/Track")]
    public class TrackGrievanceModel :IModel
    {
        public long Id { get; set; }
        public string FaultRemark { get; set; }

    }
}

