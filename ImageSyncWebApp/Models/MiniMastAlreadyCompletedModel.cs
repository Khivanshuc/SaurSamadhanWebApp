using CredaData.Client;

namespace ImageSyncWebApp.Models
{
    [ApiMetadata("MiniMastAlreadyCompleted")]
    public class MiniMastAlreadyCompletedModel : IModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long DistrictId { get; set; }
        public long BlockId { get; set; }
        public long VillageId { get; set; }
        public long SiteId { get; set; }
        public long ProjectId { get; set; }
        public string Email { get; set; }
        public string SIName { get; set; }
        public DateTime InspectionDate { get; set; }
        public bool IsSystemWorking { get; set; }
        public string NumberOfWorkingLights { get; set; }
        public string NumberOfNotWorkingLights { get; set; }
        public string SystemWorkingHours { get; set; }
        public byte[] UploadImage { get; set; }
        public string UploadImageType { get; set; }
        public string ImageGeoTag { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsUploaded { get; set; }

        public long AssignedTo { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Status { get; set; }

        public long SIId { get; set; }
    }
}
