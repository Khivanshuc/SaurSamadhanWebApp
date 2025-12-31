using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("stage")]
    public class StageModel : IModel
    {
        public long Id { get; set; }
        public long StageId { get; set; }
        public string StageName { get; set; }
        public long ProjectId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

    }

}
