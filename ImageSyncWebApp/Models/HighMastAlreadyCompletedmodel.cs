using CredaData.Client;

namespace ImageSyncWebApp.Models
{
    [ApiMetadata("highmastalreadycompleted")]
    public class HighMastAlreadyCompletedmodel : IModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public long SiteId { get; set; }
        public long ProjectId { get; set; }
        public long BlockId { get; set; }
        public float SystemWorkingHours { get; set; }
        public byte[] ImageWithCompleteSystem { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsUploaded { get; set; }
    }
}
