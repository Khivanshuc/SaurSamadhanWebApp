using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("grievance")]
    public class GrievanceModel : IModel
    {
        public long Id { get; set; }
        public long DistrictId { get; set; }
        public long BlockId { get; set; }
        public long VillageId { get; set; }
        public string Region { get; set; }
        public string Area { get; set; }
        public long SiteId { get; set; }
        public long AssignedTo { get; set; }
        public string AssignedToNumber { get; set; }
        public long ProjectId { get; set; }
        public string FaultRemark { get; set; }
        public byte[] FaultImage { get; set; }
        public string FaultImageGeoTag { get; set; }
        public string FaultImageType { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string GrievanceStatus { get; set; }
        public string Severity { get; set; }
        public long SIId { get; set; }
        public string AdminComment { get; set; }
        public DateTime? OpenDate { get; set; }
        public byte[] MobilePhoto { get; set; }
        public string MobilePhotoGeoTag { get; set; }
        public string MobilePhotoType { get; set; }
        public string VerifyComment { get; set; }
        public DateTime? VerifyDate { get; set; }
        public byte[] CertificatePhoto { get; set; }
        public DateTime? CloseDate { get; set; }
        public bool? IsActive { get; set; }

        public bool IsSystemWorking { get; set; }
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
        public bool? SiWorkingStatus { get; set; }
        public string RemarkDuringInspection { get; set; }
        public string SSYSite { get; set; }

        public long? RejectionStatus { get; set; }
        public string RejectionTechnicianComment { get; set; }
        public byte[] ImageBeforeRectification { get; set; }
        public DateTime? ComplaintVerificationDate { get; set; }

        public DateTime? SIAssignedDate { get; set; }
        public bool? SiIsAssign { get; set; }
        public bool? SITimeWorkingStatus { get; set; }
        public string SIRectificationRemark { get; set; }
        public byte[] SIUploadImage { get; set; }
        public byte[] SIUploadPDF { get; set; }
        public string SiImageGPS { get; set; }
        public DateTime? SIClosedDate { get; set; }
        public string SITimeSystemWorkingStatus { get; set; }
        public bool IsForwardedToHO { get; set; }
        public bool IsRejectedByHO { get; set; }
        public bool IsRevertedByHO { get; set; }
        public bool IsAcceptedByHO { get; set; }
        public bool IsForwardedToZO { get; set; }
        public bool IsRejectedByZO { get; set; }
        public bool IsRevertedByZO { get; set; }
        public bool IsAcceptedByZO { get; set; }
        public DateTime? DIClosingDate { get; set; }
        public DateTime? ZOClosingDate { get; set; }
        public DateTime? HOClosingDate { get; set; }

        public bool? IsManualGrievance { get; set; }
        public bool? IsDeleted { get; set; }
    }
}