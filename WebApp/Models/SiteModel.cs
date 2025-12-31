using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("site")]
    public class SiteModel : IModel
    {
        public long Id { get; set; }
        public long? SiteId { get; set; }
        public string SiteName { get; set; }
        public long? DistrictId { get; set; }
        public long? BlockId { get; set; }
        public long? VillageId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? SIId { get; set; }
        public long? ProjectId { get; set; }
        public DateTime? CommissioningDate { get; set; }
    }
}
