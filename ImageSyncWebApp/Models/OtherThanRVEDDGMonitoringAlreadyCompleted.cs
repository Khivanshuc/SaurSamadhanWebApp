using CredaData.Client;

namespace ImageSyncWebApp.Models
{
    [ApiMetadata("OtherThanRVEDDGMonitoringAlreadyCompleted")]
    public class OtherThanRVEDDGMonitoringAlreadyCompleted : IModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long DistrictId { get; set; }
        public long BlockId { get; set; }
        public long VillageId { get; set; }
        public long SiteId { get; set; }
        public long ProjectId { get; set; }
        public string SIName { get; set; }
        public DateTime? InspectionDate { get; set; }
        public bool IsSystemWorking { get; set; }
        public string IsSystemWorkingRemarks { get; set; }
        public string MeterReading { get; set; }
        public bool IsInvertorWorking { get; set; }
        public string AHChargingMeterReading { get; set; }
        public string AHDisChargingMeterReading { get; set; }
        public string NumberOfBatteries { get; set; }
        public string BatteryAH { get; set; }
        public string BatteryRatedVoltage { get; set; }
        public string TotalVoltage { get; set; }
        public string TotalCurrent { get; set; }
        public string NumberOfDefectiveBattery { get; set; }
        public string NumberOfDefectiveModule { get; set; }
        public byte[] SystemWorkingImage { get; set; }
        public string SystemWorkingImageGeoTag { get; set; }
        public string SystemWorkingImageType { get; set; }
        public byte[] SystemMaintanenceImage { get; set; }
        public string SystemMaintanenceImageGeoTag { get; set; }
        public string SystemMaintanenceImageType { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsUploaded { get; set; }


    }

}
