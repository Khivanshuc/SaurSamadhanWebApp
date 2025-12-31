using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("complaintRegister")]
    public class ComplaintRegisterModel : IModel
    {
        public long Id { get; set; }
        public string ComplaintNumber { get; set; }
        public long? UserId { get; set; }
        public long? DistrictId { get; set; }
        public long? BlockId { get; set; }
        public long? VillageId { get; set; }
        public long? SiteId { get; set; }
        public bool? ComplaintStatus { get; set; }
        public DateTime? ComplaintDate { get; set; }
        public string ComplaintRemark { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string BeneficiaryName { get; set; }
        public long? ComplaintReceiveMedium { get; set; }
        public bool? ActionTakenByDistrict { get; set; }
        public long? PublicGrievanceId { get; set; }
        public DateTime? LetterDate { get; set; }
        public string LetterNumber { get; set; }
        public long? LetterSentTo { get; set; }
        public byte[] UploadLetter { get; set; }
        public byte[] OtherAttachment { get; set; }
        public bool? ForwardedToDO { get; set; }
        public bool? ForwardedToZO { get; set; }
        public bool? ForwardedToHO { get; set; }
    }
}