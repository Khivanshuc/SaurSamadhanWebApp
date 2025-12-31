using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("grievance/count")]
    public class GrievanceCountModel : IModel
    {
        public long Id { get; set; }
        public int OpenGrievanceCount { get; set; }
        public int InProgressGrievanceCount { get; set; }
        public int VerifiedGrievanceCount { get; set; }
        public int ClosedGrievanceCount { get; set; }
        public int TotalGrievanceCount { get; set; }
    }
}
