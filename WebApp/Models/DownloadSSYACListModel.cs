using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("ssyalreadycompleted/admin/SSYDownloadProjectList")]
    public class DownloadSSYACListModel : IModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public string VillageName { get; set; }
        public string PlaceOrBeneficiaryId { get; set; }
        public string PlaceOrBeneficiaryName { get; set; }
        public string SiteName { get; set; }
        public string ProjectName { get; set; }
        public string SIName { get; set; }
        public DateTime InspectionDate { get; set; }
        public string IsSystemWorking { get; set; }
        public string IsSystemWorkingRemarks { get; set; }
        public string PumpStatus { get; set; }
        public string ControllerStatus { get; set; }
        public string SystemLayout { get; set; }
        public string IsModuleWorking { get; set; }
        public string NumberOfModules { get; set; }
        public string ModuleCapacity { get; set; }
        public string StructureStatus { get; set; }
        public string ControllerMake { get; set; }
        public string PipelineStatus { get; set; }
        public string LightingArrester { get; set; }
        public string IsWaterLeaking { get; set; }
        public string TankLidStatus { get; set; }
        public string IsSensorWorking { get; set; }
        public string IsUnionWorking { get; set; }
        public string IsNippleWorking { get; set; }
        public string IsSocketWorking { get; set; }
        public string IsGateValveWorking { get; set; }
        public string IsCableWorking { get; set; }
        public string IsRopeWireWorking { get; set; }
        public string IsStandPostCorrectionNeeded { get; set; }
        public string IsSystemClean { get; set; }
        public DateTime LastWaterTankCleanDate { get; set; }
        public string SystemWorkingImage { get; set; }
        public string GeoTag { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
