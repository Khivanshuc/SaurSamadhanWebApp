using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("biogasalreadycompleted")]
    public class BiogasAlreadyCompletedModel
    {
        public long Id { get; set; }
        public string EmailId { get; set; }
        public DateTime InspectionDate { get; set; }
        public string UserName { get; set; }
        public string UserDesignation { get; set; }
        public string UserMobileNumber { get; set; }
        public string GramName { get; set; }
        public string GramPanchayatName { get; set; }
        public long BlockId { get; set; }
        public string BeneficiaryName { get; set; }
        public int BiogasInstallationYear { get; set; }
        public string BiogasMeshanName { get; set; }
        public string BiogasSEWName { get; set; }
        public string BeneficiaryClass { get; set; }
        public float DinbandhuBiogasCapacity { get; set; }
        public string ConstructionMaterial { get; set; }
        public string SystemConstructionStatus { get; set; }
        public string ExtraConstructionMaterial { get; set; }
        public bool? IsWorking { get; set; }
        public byte[] UploadPhoto { get; set; }
        public string Remarks { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsUploaded { get; set; }
    }
}
