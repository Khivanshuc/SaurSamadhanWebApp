using CredaData.Client;

namespace ImageSyncWebApp.Models
{
    [ApiMetadata("ssyalreadycompleted")]
    public class SSYalreadyCompletedModel : IModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long SiteId { get; set; }
        public long ProjectId { get; set; }
        public string SIName { get; set; }
        public DateTime InspectionDate { get; set; }
        public bool IsSystemWorking { get; set; }
        public string IsSystemWorkingRemarks { get; set; }
        public bool PumpStatus { get; set; }
        public bool ControllerStatus { get; set; }
        public string SystemLayout { get; set; }
        public bool IsModuleWorking { get; set; }
        public string NumberOfModules { get; set; }
        public string ModuleCapacity { get; set; }
        public bool StructureStatus { get; set; }
        public string ControllerMake { get; set; }
        public bool PipelineStatus { get; set; }
        public bool LightingArrester { get; set; }
        public bool IsWaterLeaking { get; set; }
        public bool TankLidStatus { get; set; }
        public bool IsSensorWorking { get; set; }
        public bool IsUnionWorking { get; set; }
        public bool IsNippleWorking { get; set; }
        public bool IsSocketWorking { get; set; }
        public bool IsGateValveWorking { get; set; }
        public bool IsCableWorking { get; set; }
        public bool IsRopeWireWorking { get; set; }
        public bool IsStandPostCorrectionNeeded { get; set; }
        public bool IsSystemClean { get; set; }
        public DateTime LastWaterTankCleanDate { get; set; }
        public byte[] SystemWorkingImage { get; set; }
        public string GeoTag { get; set; }
        public string SystemWorkingImageType { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsUploaded { get; set; }
    }
}
