using CredaData.Client;

namespace WebApp.Models
{
    public class VwSSYalreadyCompletedModel
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
        public string SystemWorkingImage { get; set; }
        public string GeoTag { get; set; }
        public string SystemWorkingImageType { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsUploaded { get; set; }
    }
}
