using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("grievanceDeleteLog")]
    public class GrievanceDeleteLogModel : IModel
    {
        public long Id { get; set; }
        public long? GrievanceId { get; set; }
        public string Remark { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

    }
}
