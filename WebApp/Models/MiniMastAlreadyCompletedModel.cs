using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("minimastalreadycompleted")]

    public class MiniMastAlreadyCompletedModel
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string SIName { get; set; }
        public string SiteName { get; set; }
        public DateTime InspectionDate { get; set; }
        public string BlockName { get; set; }
        public bool IsLightWorking { get; set; }
        public float SystemWorkingHours { get; set; }
        public byte[] UploadImage { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsUploaded { get; set; }
    }
}
