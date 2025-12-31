using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("block/grievance")]
    public class AreaBasedGrievanceCountModel :IModel
    {
        public long Id { get; set; }
        public string AreaName { get; set; }
        public int? GrievanceCount { get; set; }
    }
}

