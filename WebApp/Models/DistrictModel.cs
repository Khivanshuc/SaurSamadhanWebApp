using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("district")]
    public class DistrictModel : IModel
    {
        public long Id { get; set; }
        public long DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }

}
