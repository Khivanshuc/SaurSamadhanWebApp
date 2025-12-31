using CredaData.Client;

namespace ImageSyncWebApp.Models
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
    }
}
