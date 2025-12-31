using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("biogasalreadycompleted/admin/BioGasDownloadProjectList")]
    public class DownloadBioGasListModel : IModel
    {
        public long Id { get; set; }
        public string User { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string Village { get; set; }
        public string Site { get; set; }
        public string Project { get; set; }
        public DateTime InspectionDate { get; set; }
        public string InspectorDesignation { get; set; }
        public string GramName { get; set; }
        public string GramPanchayatName { get; set; }
        public string BeneficiaryName { get; set; }
        public string BiogasInstallationYear { get; set; }
        public string BiogasMeshanName { get; set; }
        public string BiogasSEWName { get; set; }
        public string BeneficiaryClass { get; set; }
        public string DinbandhuBiogasCapacity { get; set; }
        public string ConstructionMaterial { get; set; }
        public string SystemConstructionStatus { get; set; }
        public string ExtraConstructionMaterial { get; set; }
        public string IsSystemWorking { get; set; }
        public string UploadPhoto { get; set; }
        public string GeoTag { get; set; }
        public string Remarks { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Status { get; set; }
        public DateTime AssignedDate { get; set; }
        public string AssignedTo { get; set; }
        public long SIId { get; set; }
    }
}
