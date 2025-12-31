using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("block")]
    public class BlockModel : IModel
    {
        public long Id { get; set; }
        public string BlockName { get; set; }
        public long BlockId { get; set; }
        public long DistrictId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }

}
