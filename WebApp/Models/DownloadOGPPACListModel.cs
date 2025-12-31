using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("OnGridPowerPlantAlreadyCompleted/admin/OGPPDownloadProjectList")]
    public class DownloadOGPPACListModel : IModel
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
        public string IsSystemWorkingRemarks { get; set; }
        public string MeterReading { get; set; }
        public long InvertorCount { get; set; }
        public long FaultInvertorCount { get; set; }
        public long SolarModuleCount { get; set; }
        public string SolarmoduleCapacity { get; set; }
        public long FaultSolarModuleCount { get; set; }
        public string DCCombinerBoxStatus { get; set; }
        public string ACCombinerBoxStatus { get; set; }
        public string EarthingStatus { get; set; }
        public string LAStatus { get; set; }
        public string RMSInstallationStatus { get; set; }
        public string RMSWorkingStatus { get; set; }
        public string RMSFaultRemark { get; set; }
        public string SystemWorkingImage { get; set; }
        public string SystemMaintanenceImage { get; set; }
        public string SystemWorkingImageGeoTag { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Status { get; set; }
        public DateTime AssignedDate { get; set; }
        public long AssignedTo { get; set; }
        public long SIId { get; set; }
    }
}
