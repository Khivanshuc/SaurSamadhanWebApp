using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("otherthanjjmalreadycompleted/admin")]
    public class VwOTJJMAlreadyCompletedModel : IModel
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
        public bool IsSystemWorking { get; set; }
        public string IsSystemWorkingRemark { get; set; }
        public bool? IsPumpWorking { get; set; }
        public bool? IsControllerWorking { get; set; }
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
        public DateTime? LastWaterTankCleanDate { get; set; }
        public string ImageWithFunctionality { get; set; }
        public string ImageWithFunctionalityType { get; set; }
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
