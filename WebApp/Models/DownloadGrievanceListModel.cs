using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("grievance/admin/DownloadGrievanceList")]
    public class DownloadGrievanceListModel : IModel
    {
        public long Id { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public string VillageName { get; set; }
        public string Region { get; set; }
        public string BeneficiaryName { get; set; }
        public string SiteName { get; set; }
        public string UserName { get; set; }
        public string ProjectName { get; set; }
        public string ComplaintDescription { get; set; }
        public string FaultImageGeoTag { get; set; }
        public string ApplicantMobNo { get; set; }
        public string ComplaintDate { get; set; }
        public string ComplaintPlace { get; set; }
        public string GrievanceStatus { get; set; }
        public string Severity { get; set; }
        public string? SIName { get; set; }
        public string? AssignTo { get; set; }
        public string AdminComment { get; set; }
        public string VerifyDate { get; set; }
        public string VerifyComment { get; set; }
        public string OpenDate { get; set; }
        public string CloseDate { get; set; }
        public string RemarkDuringInspection { get; set; }
        public bool? IsActive { get; set; }
        public string CommissioningDate { get; set; }
        public string ComplaintMedium { get; set; }
        public string GrievanceForwardStatus { get; set; }
    }
}
