using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("SSYRegistrationForm/admin/ssyRegDetail")]
    public class VwSSYRegistrationFormModel : IModel
    {
        public long Id { get; set; }
        public string ApplicantName { get; set; }
        public string ProjectName { get; set; }
        public string Gender { get; set; }
        public string FatherName { get; set; }
        public string InstallationSite { get; set; }
        public string ApplicantAddress { get; set; }
        public string VidhansabhaRegion { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public string ApplicantMobileNum { get; set; }
        public string AadharNumber { get; set; }
        public string VoterIdNumber { get; set; }
        public string ElectricConnectionSerialNumber { get; set; }
        public string KhasraNumber { get; set; }
        public string TotalArea { get; set; }
        public string WaterSource { get; set; }
        public string Caste { get; set; }
        public string PumpCapacity { get; set; }
        public string SolarPumpType { get; set; }
        public string PumpChoice { get; set; }

        public string SystemCost { get; set; }
        public string AmountWithGST { get; set; }
        public string StateGrant { get; set; }
        public string CentralGrant { get; set; }
        public string ApplicationCostToBePaidByUser { get; set; }
        public string ApplicationCost { get; set; }

        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }
        public string DD_Number { get; set; }
        public string DD_Date { get; set; }
        public string DD_BankName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
