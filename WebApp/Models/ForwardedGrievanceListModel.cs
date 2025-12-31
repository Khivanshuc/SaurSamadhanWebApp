using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("GrievanceForwarding/admin/GetForwardedGrievanceList")]
    public class ForwardedGrievanceListModel : IModel
    {
        public long Id { get; set; }
        public long GrievanceId { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public string VillageName { get; set; }
        public string SiteName { get; set; }
        public string DIForwardingRemark { get; set; }
        public DateTime DIForwardingDate { get; set; }
        public string ForwardedGrievanceStatus { get; set; }
    }

}
