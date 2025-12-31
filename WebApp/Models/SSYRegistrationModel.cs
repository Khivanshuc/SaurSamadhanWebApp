using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("SSYRegistrationForm")]
    public class SSYRegistrationModel : IModel
    {
        public long Id { get; set; }
        public string ApplicantName { get; set; }
        public string Gender { get; set; }
        public string FatherName { get; set; }
        public string InstallationSite { get; set; }
        public string ApplicantAddress { get; set; }
        public string VidhansabhaRegion { get; set; }
        public long DistrictId { get; set; }
        public long BlockId { get; set; }
        public string ApplicantMobileNum { get; set; }
        public string AadharNumber { get; set; }
        public string VoterIdNumber { get; set; }
        public string ElectricConnectionSerialNumber { get; set; }
        public string KhasraNumber { get; set; }
        public string TotalArea { get; set; }
        public string WaterSource { get; set; }
        public long? CasteId { get; set; }
        public long? PumpCapacityId { get; set; }
        public long? SolarPumpTypeId { get; set; }
        public long? PumpChoiceId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}