using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("complaintStatusHistory")]
    public class ComplaintStatusHistoryModel : IModel
    {
        public long Id { get; set; }
        public long? ComplaintId { get; set; }
        public string ComplaintNumber { get; set; }
        public bool? IsApprovedByDO { get; set; }
        public bool? IsApprovedByZO { get; set; }
        public bool? IsApprovedByHO { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}