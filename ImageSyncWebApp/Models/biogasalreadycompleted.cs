using CredaData.Client;

namespace ImageSyncWebApp.Models
{
    [ApiMetadata("biogasalreadycompleted")]
    public class biogasalreadycompleted : IModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long SiteId { get; set; }
        public long ProjectId { get; set; }
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
        public bool IsSystemWorking { get; set; }
        public byte[] UploadPhoto { get; set; }
        public string GeoTag { get; set; }
        public string UploadPhotoType { get; set; }
        public string Remarks { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsUploaded { get; set; }
    }
}
