using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("complaintAudit")]
    public class ComplaintAuditModel : IModel
    {
        public long Id { get; set; }
        public long? ComplaintId { get; set; }
        public string ComplaintNumber { get; set; }
        public long? OfficeLevel { get; set; }
        public bool? IsAccepted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
