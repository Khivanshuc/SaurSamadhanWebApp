using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("complaintAction")]
    public class ComplaintActionModel : IModel
    {
        public long Id { get; set; }
        public long? ComplaintId { get; set; }
        public string ComplaintNumber { get; set; }
        public long? SystemIntegratorId { get; set; }
        public DateTime? AssignedDatetoSI { get; set; }
        public long? DistrictId { get; set; }
        public long? BlockId { get; set; }
        public long? VillageId { get; set; }
        public long? SiteId { get; set; }
        public long? UserId { get; set; }
        public string Remark { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? ExpectedTimeLimit { get; set; }

    }
}
