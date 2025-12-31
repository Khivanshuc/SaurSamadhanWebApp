using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("complaintEscalation")]
    public class ComplaintEscalationModel : IModel
    {
        public long Id { get; set; }
        public long EscalatedBy { get; set; }
        public long EscalatedTo { get; set; }
        public long ComplaintId { get; set; }
        public string ComplaintNumber { get; set; }
        public bool IsAccepted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}