using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("GrievanceForwarding")]
    public class ForwardingGrievanceModel : IModel
    {
        public long Id { get; set; }
        public long GrievanceId { get; set; }
        public bool? IsForwardedByDO { get; set; }
        public DateTime? DIForwardingDate { get; set; }
        public string DIForwardingComment { get; set; }
        public byte[] DIForwardingDocument { get; set; }
        public bool? IsAcceptedByHO { get; set; }
        public string HOAcceptanceComment { get; set; }
        public DateTime? HOAcceptanceDate { get; set; }
        public bool? IsRejectedByHO { get; set; }
        public string HORejectionComment { get; set; }
        public DateTime? HORejectionDate { get; set; }
        public byte[] HORejectedDocument { get; set; }
        public bool? IsRevertedByHO { get; set; }
        public string HOReversionComment { get; set; }
        public DateTime? HOReversionDate { get; set; }
        public byte[] HOReversionDocument { get; set; }
        public bool? IsAcceptedByDI { get; set; }
        public string ForwardedGrievanceStatus { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public bool? IsAcceptedByZO { get; set; }
        public string ZOAcceptanceComment { get; set; }
        public DateTime? ZOAcceptanceDate { get; set; }
        public bool? IsRejectedByZO { get; set; }
        public string ZORejectionComment { get; set; }
        public byte[] ZORejectionDocument { get; set; }
        public DateTime? ZORejectionDate { get; set; }
        public bool? IsRevertedByZO { get; set; }
        public string ZOReversionComment { get; set; }
        public byte[] ZOReversionDocument { get; set; }
        public DateTime? ZOReversionDate { get; set; }
        public bool? IsForwardedByZO { get; set; }
        public DateTime? ZOForwardingDate { get; set; }
        public string ZOForwardingComment { get; set; }
        public byte[] ZOForwardingDocument { get; set; }
    }
}