using CredaData.Client;

namespace WebApp.Models
{
    public class HMalreadycompletedModel : IModel
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? DistrictId { get; set; }
        public long? BlockId { get; set; }
        public long? VillageId { get; set; }
        public long? SiteId { get; set; }
        public long? ProjectId { get; set; }
        public string SIName { get; set; }
        public DateTime? InspectionDate { get; set; }
        public bool? IsSystemWorking { get; set; }
        public string NumberOfWorkingLights { get; set; }
        public string NumberOfNotWorkingLights { get; set; }
        public string RopeWireStatus { get; set; }
        public string SystemWorkingHours { get; set; }
        public byte[] ImageWithCompleteSystem { get; set; }
        public string ImageWithCompleteSystemType { get; set; }
        public string ImageGeoTag { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsUploaded { get; set; }
        public string Status { get; set; }
        public DateTime? AssignedDate { get; set; }
        public long? AssignedTo { get; set; }
        public long? SIId { get; set; }


    }
}
