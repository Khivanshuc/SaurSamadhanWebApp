using CredaData.Client;

namespace ImageSyncWebApp.Models
{
    [ApiMetadata("OnGridPowerPlantAlreadyCompleted")]
    public class OnGridPowerPlantAlreadyCompletedModel : IModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long DistrictId { get; set; }
        public long BlockId { get; set; }
        public long VillageId { get; set; }
        public long SiteId { get; set; }
        public long ProjectId { get; set; }
        public string SIName { get; set; }
        public DateTime InspectionDate { get; set; }
        public bool IsSystemWorking { get; set; }
        public string IsSystemWorkingRemarks { get; set; }
        public string MeterReading { get; set; }
        public long InvertorCount { get; set; }
        public long FaultInvertorCount { get; set; }
        public long SolarModuleCount { get; set; }
        public string SolarmoduleCapacity { get; set; }
        public long FaultSolarModuleCount { get; set; }
        public bool DCCombinerBoxStatus { get; set; }
        public bool ACCombinerBoxStatus { get; set; }
        public bool EarthingStatus { get; set; }
        public bool LAStatus { get; set; }
        public bool RMSInstallationStatus { get; set; }
        public bool RMSWorkingStatus { get; set; }
        public string RMSFaultRemark { get; set; }
        public byte[] SystemWorkingImage { get; set; }
        public string SystemWorkingImageType { get; set; }
        public byte[] SystemMaintanenceImage { get; set; }
        public string SystemMaintanenceImageType { get; set; }
        public string SystemWorkingImageGeoTag { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsUploaded { get; set; }
        public string Status { get; set; }
        public DateTime AssignedDate { get; set; }
        public long AssignedTo { get; set; }
        public long SIId { get; set; }
    }   
}       
        
        
        
        
       