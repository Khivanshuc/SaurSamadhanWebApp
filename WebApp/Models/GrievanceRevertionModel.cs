using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("grievanceRevertion")]
    public class GrievanceRevertionModel : IModel
    {
        public long Id { get; set; }
        public long? GrievanceId { get; set; }
        public string GrievanceRevertionComment { get; set; }
        public string GrievanceRevertionType { get; set; }
        public string RevertedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
