using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("otherthanjjmalreadycompleted")]
    public class RVEDDGalreadycompleted : IModel
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public long? DistrictId { get; set; }
        public long? BlockId { get; set; }
        public long? VillageId { get; set; }
        public long? SiteId { get; set; }
        public long? ProjectId { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string SIName { get; set; }
        public string SystemName { get; set; }
        public bool? IsSystemWorking { get; set; }
        public string MonthlyWorkingDays { get; set; }
        public string NumberOfBattery { get; set; }
        public string BatteryAH { get; set; }
        public string BatteryRatedVoltage { get; set; }
        public string MeasuredBatteryBankVoltage { get; set; }
        public DateTime? LastDateSystemDistilledWater { get; set; }
        public string NumberOfEstablishedSolarPanel { get; set; }
        public string SolarPanelCapacity { get; set; }
        public string TotalArray { get; set; }
        public string VoltageArray1 { get; set; }
        public string VoltageArray2 { get; set; }
        public string VoltageArray3 { get; set; }
        public string VoltageArray4 { get; set; }
        public string VoltageArray5 { get; set; }
        public string VoltageArray6 { get; set; }
        public string VoltageArray7 { get; set; }
        public string VoltageArray8 { get; set; }
        public string VoltageArray9 { get; set; }
        public string VoltageArray10 { get; set; }
        public string CurrentArray1 { get; set; }
        public string CurrentArray2 { get; set; }
        public string CurrentArray3 { get; set; }
        public string CurrentArray4 { get; set; }
        public string CurrentArray5 { get; set; }
        public string CurrentArray6 { get; set; }
        public string CurrentArray7 { get; set; }
        public string CurrentArray8 { get; set; }
        public string CurrentArray9 { get; set; }
        public string CurrentArray10 { get; set; }
        public string TotalVoltage { get; set; }
        public string TotalCurrent { get; set; }
        public string EnergyMeterReading { get; set; }
        public string AHChargingMeterReading { get; set; }
        public string AhDischargingMeterReading { get; set; }
        public string NumberOfPoles { get; set; }
        public string NumberOfFamilyMembersWithSystem { get; set; }
        public string NumberOfSystemWorkingConnection { get; set; }
        public string NumberOfEstablishedStreetLight { get; set; }
        public string SystemWorkingHours { get; set; }
        public string NumberOfWorkingStreetLights { get; set; }
        public string IsSystemWorkingRemarks { get; set; }
        public string NumberOfDefectiveBattery { get; set; }
        public string NumberOfDefectiveModule { get; set; }
        public string IsInvertorWorking { get; set; }
        public string PDNStatusRemark { get; set; }
        public string AnyOtherRemark { get; set; }
        public byte[] ImageWithPanelAndControlRoom { get; set; }
        public string ImageWithPanelAndControlRoomType { get; set; }
        public byte[] ImageWithPDN { get; set; }
        public string ImageWithPDNType { get; set; }
        public byte[] ImageWithFunctionality { get; set; }
        public string ImageWithFunctionalityType { get; set; }
        public byte[] ImageWithMeterReading { get; set; }
        public string ImageWithMeterReadingType { get; set; }
        public byte[] ImageWithMangpatra { get; set; }
        public string ImageWithMangpatraType { get; set; }
        public string GeoTag { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsUploaded { get; set; }
        public string Status { get; set; }
        public DateTime? AssignedDate { get; set; }
        public long? AssignedTo { get; set; }
        public long? SIId { get; set; }

    }
}
