using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("OtherThanRVEDDGMonitoringAlreadyCompleted/admin/OTRVEDDGDownloadProjectList")]
    public class DownloadOTRVEDDGACListModel : IModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public string VillageName { get; set; }
        public string SiteName { get; set; }
        public string ProjectName { get; set; }
        public string SIName { get; set; }
        public DateTime InspectionDate { get; set; }
        public string IsSystemWorking { get; set; }
        public string IsSystemWorkingRemarks { get; set; }
        public string MeterReading { get; set; }
        public string IsInvertorWorking { get; set; }
        public string AHChargingMeterReading { get; set; }
        public string AHDisChargingMeterReading { get; set; }
        public string NumberOfBatteries { get; set; }
        public string BatteryAH { get; set; }
        public string BatteryRatedVoltage { get; set; }
        public string TotalVoltage { get; set; }
        public string TotalCurrent { get; set; }
        public string NumberOfDefectiveBattery { get; set; }
        public string NumberOfDefectiveModule { get; set; }
        public string SystemWorkingImageBase64 { get; set; }
        public string SystemWorkingImageGeoTag { get; set; }
        public string SystemMaintanenceImageBase64 { get; set; }
        public string SystemMaintanenceImageGeoTag { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
