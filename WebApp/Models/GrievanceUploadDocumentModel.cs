using CredaData.Client;

namespace WebApp.Models
{
    public class GrievanceUploadDocumentModel
    {
        public long Id { get; set; }
        public long GrievanceId { get; set; }
        public string GeoTag { get; set; }
        public byte[] Image { get; set; }
        public byte[] Document { get; set; }
        public string ImageBase64 { get; set; } // New property for Base64 image
        public string DocumentBase64 { get; set; } // New property for Base64 document
        public string VerificationComment { get; set; }
        public DateTime DateTime { get; set; }
        public string GrievanceStatus { get; set; }
    }
}