using CredaData.Client;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    [ApiMetadata("grievance/id")]
    public class VwGrievanceModel : IModel
    {
        public long Id { get; set; }
        public long DistrictId { get; set; }
        public string DistrictName { get; set; }
        public long BlockId { get; set; }
        public string BlockName { get; set; }
        public long VillageId { get; set; }
        public string VillageName { get; set; }
        public string Region { get; set; }
        public string Area { get; set; }
        public long SiteId { get; set; }
        public string SiteName { get; set; }
        public string UserName { get; set; }
        public string ProjectName { get; set; }
        public string FaultRemark { get; set; }
        public byte[] FaultImage { get; set; }
        public string FaultImageGeoTag { get; set; }
        public string FaultImageType { get; set; }
        public string MobileNumber { get; set; }
        public string CreatedOn { get; set; }
        public string GrievanceStatus { get; set; }
        public string Severity { get; set; }
        public string? SIName { get; set; }
        public string? AssignTo { get; set; }
        public string AdminComment { get; set; }
        public string OpenDate { get; set; }
        public byte[] MobilePhoto { get; set; }
        public string MobilePhotoGeoTag { get; set; }
        public string MobilePhotoType { get; set; }
        public string VerifyComment { get; set; }
        public string VerifyDate { get; set; }
        public byte[] CertificatePhoto { get; set; }
        public string CloseDate { get; set; }
        public bool? IsActive { get; set; }

        public string FaultImageBase64 { get; set; }
        public string MobilePhotoBase64 { get; set; }
        public string CertificatePhotoBase64 { get; set; }


        public string IsSystemWorking { get; set; }
        public string NotWorkingStatus { get; set; }
        public long DaysForResolve { get; set; }
        public bool IsClosedByDO { get; set; }
        public string DORemark { get; set; }
        public bool IsClosedByZO { get; set; }
        public string ZORemark { get; set; }
        public bool IsClosedByHO { get; set; }
        public string HORemark { get; set; }
        public bool IsAssign { get; set; }
        public string ApplicantName { get; set; }
        public string SIWorkingStatus { get; set; }
        public string RemarkDuringInspection { get; set; }
        public string SSYSite { get; set; }
        public byte[] ImageBeforeRectification { get; set; }
        public string ComplaintVerificationDate { get; set; }
        public string ImageBeforeRectificationBase64 { get; set; }
        public bool IsForwardedToHO { get; set; }
        public bool IsRejectedByHO { get; set; }
        public bool IsRevertedByHO { get; set; }
        public bool IsAcceptedByHO { get; set; }
        public bool IsForwardedToZO { get; set; }
        public bool IsRejectedByZO { get; set; }
        public bool IsRevertedByZO { get; set; }
        public bool IsAcceptedByZO { get; set; }
        public string DIClosingDate { get; set; }
        public string ZOClosingDate { get; set; }
        public string HOClosingDate { get; set; }
    }
}
