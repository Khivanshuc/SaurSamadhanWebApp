using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("highmastalreadycompleted/admin/HMDownloadProjectList")]
    public class DownloadHMACListModel : IModel
    {
        public long Id { get; set; }
        public string User { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string Village { get; set; }
        public string Site { get; set; }
        public string Project { get; set; }
        public string SIName { get; set; }
        public DateTime InspectionDate { get; set; }
        public string IsSystemWorking { get; set; }
        public string NumberOfWorkingLights { get; set; }
        public string NumberOfNotWorkingLights { get; set; }
        public string RopeWireStatus { get; set; }
        public string SystemWorkingHours { get; set; }
        public string ImageWithCompleteSystem { get; set; }
        public string ImageGeoTag { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Status { get; set; }
        public DateTime? AssignedDate { get; set; }
        public long? AssignedTo { get; set; }
        public long? SIId { get; set; }
    }
}
