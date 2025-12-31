using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("GrievanceForwarding/admin/GetForwardedGrievanceDetail")]
    public class ForwardedGrievanceDetailModel : IModel
    {
        public long Id { get; set; }
        public long GrievanceId { get; set; }
        public long DistrictId { get; set; }
        public string DistrictName { get; set; }
        public long BlockId { get; set; }
        public string BlockName { get; set; }
        public long VillageId { get; set; }
        public string VillageName { get; set; }
        public long SiteId { get; set; }
        public string SiteName { get; set; }
        public string Region { get; set; }
        public string Area { get; set; }
        public string ProjectName { get; set; }
        public string FaultRemark { get; set; }
        public byte[] FaultImage { get; set; }
        public string FaultImageBase64 { get; set; }
        public string FaultImageGeoTag { get; set; }
        public string ApplicantMobileNumber { get; set; }
        public string ApplicantName { get; set; }
        public string GrievanceStatus { get; set; }
        public string Severity { get; set; }
        public string SIName { get; set; }
        public string AssignTo { get; set; }
        public string AdminComment { get; set; }
        public string DIForwardingRemark { get; set; }
        public string DIForwardingDate { get; set; }
        public byte[] DIForwardingDocument { get; set; }
        public string DIForwardingDocumentBase64 { get; set; }
        public DateTime? ComplaintDate { get; set; }
        public DateTime? OpenDate { get; set; }
        public byte[] ImageBeforeRectification { get; set; }
        public string ImageBeforeRectificationBase64 { get; set; }
        public bool IsAssign { get; set; }
        public DateTime? VerifyDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsForwardedByDI { get; set; }
        public bool IsAcceptedByHO { get; set; }
        public bool IsAcceptedByDI { get; set; }
        public bool IsRejectedByHO { get; set; }
        public bool IsRevertedByHO { get; set; }

        public string HOAcceptanceComment { get; set; }
        public string HOAcceptanceDate { get; set; }

        public string HORejectionComment { get; set; }
        public string HORejectionDate { get; set; }
        public byte[] HORejectedDocument { get; set; }
        public string HORejectedDocumentBase64 { get; set; }

        public string HOReversionComment { get; set; }
        public string HOReversionDate { get; set; }
        public byte[] HOReversionDocument { get; set; }
        public string HOReversionDocumentBase64 { get; set; }


        //Zonal
        public bool IsAcceptedByZO { get; set; }
        public string ZOAcceptanceComment { get; set; }
        public string ZOAcceptanceDate { get; set; }

        public bool IsRejectedByZO { get; set; }
        public string ZORejectionComment { get; set; }
        public string ZORejectionDate { get; set; }
        public byte[] ZORejectionDocument { get; set; }
        public string ZORejectionDocumentBase64 { get; set; }

        public bool IsRevertedByZO { get; set; }
        public string ZOReversionComment { get; set; }
        public string ZOReversionDate { get; set; }
        public byte[] ZOReversionDocument { get; set; }
        public string ZOReversionDocumentBase64 { get; set; }

        public bool IsForwardedByZO { get; set; }
        public string ZOForwardingComment { get; set; }
        public string ZOForwardingDate { get; set; }
        public byte[] ZOForwardingDocument { get; set; }
        public string ZOForwardingDocumentBase64 { get; set; }

    }

}
