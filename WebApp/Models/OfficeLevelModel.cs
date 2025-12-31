using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("officelevel")]
    public class OfficeLevelModel : IModel
    {
        public long Id { get; set; }
        public string OfficeName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }

}
