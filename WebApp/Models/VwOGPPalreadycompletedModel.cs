using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("OnGridPowerPlantAlreadyCompleted/admin")]
    public class VwOGPPalreadycompletedModel : IModel
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
        public string SystemWorkingImage { get; set; }
        public string SystemWorkingImageType { get; set; }
        public string SystemMaintanenceImage { get; set; }
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
