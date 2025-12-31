using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("otherthanjjmalreadycompleted/admin/OTJJMDownloadProjectList")]
    public class DownloadOTJJMACListModel : IModel
    {
        public long Id { get; set; }
        public string User { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string Village { get; set; }
        public string Site { get; set; }
        public string Project { get; set; }
        public string SIName { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string IsSystemWorking { get; set; }
        public string IsSystemWorkingRemark { get; set; }
        public string? IsPumpWorking { get; set; }
        public string? IsControllerWorking { get; set; }
        public string SystemLayout { get; set; }
        public string PanelMake { get; set; }
        public string PanelVolt { get; set; }
        public string PanelCapacity { get; set; }
        public string NumberOfPanel { get; set; }
        public string ControllerMake { get; set; }
        public string PumpMake { get; set; }
        public string IsHandpumpWorking { get; set; }
        public string StandpostCondition { get; set; }
        public string DefectiveNumberOfModules { get; set; }
        public string IsSystemClean { get; set; }
        public string IsTapWorking { get; set; }
        public string IsWaterTankLeaking { get; set; }
        public string IsTankLidPresent { get; set; }
        public string IsSensorWorking { get; set; }
        public string IsUnionWorking { get; set; }
        public string IsNippleWorking { get; set; }
        public string IsSocketWorking { get; set; }
        public string IsGateValveWorking { get; set; }
        public string IsCableWorking { get; set; }
        public string IsRopeWireWorking { get; set; }
        public string IsStandPostCorrectionNeeded { get; set; }
        public DateTime? LastWaterTankCleanDate { get; set; }
        public string ImageWithFunctionality { get; set; }
        public string GeoTag { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Status { get; set; }
        public DateTime? AssignedDate { get; set; }
        public long? AssignedTo { get; set; }
        public long? SIId { get; set; }
    }
}
