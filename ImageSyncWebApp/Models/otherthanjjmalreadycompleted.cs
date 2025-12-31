using CredaData.Client;

namespace ImageSyncWebApp.Models
{
    [ApiMetadata("otherthanjjmalreadycompleted")]
    public class otherthanjjmalreadycompleted : IModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long SiteId { get; set; }
        public long ProjectId { get; set; }
        public string SIName { get; set; }
        public DateTime InspectionDate { get; set; }
        public bool IsSystemWorking { get; set; }
        public string IsSystemWorkingRemark { get; set; }
        public bool IsPumpWorking { get; set; }
        public bool IsControllerWorking { get; set; }
        public string SystemLayout { get; set; }
        public string PanelMake { get; set; }
        public bool PanelVolt { get; set; }
        public string PanelCapacity { get; set; }
        public string NumberOfPanel { get; set; }
        public string ControllerMake { get; set; }
        public string PumpMake { get; set; }
        public bool IsHandpumpWorking { get; set; }
        public bool StandpostCondition { get; set; }
        public string DefectiveNumberOfModules { get; set; }
        public bool IsSystemClean { get; set; }
        public bool IsTapWorking { get; set; }
        public bool IsWaterTankLeaking { get; set; }
        public bool IsTankLidPresent { get; set; }
        public bool IsSensorWorking { get; set; }
        public bool IsUnionWorking { get; set; }
        public bool IsNippleWorking { get; set; }
        public bool IsSocketWorking { get; set; }
        public bool IsGateValveWorking { get; set; }
        public bool IsCableWorking { get; set; }
        public bool IsRopeWireWorking { get; set; }
        public bool IsStandPostCorrectionNeeded { get; set; }
        public DateTime LastWaterTankCleanDate { get; set; }
        public byte[] ImageWithFunctionality { get; set; }
        public string ImageWithFunctionalityType { get; set; }
        public string GeoTag { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsUploaded { get; set; }
    }
}
