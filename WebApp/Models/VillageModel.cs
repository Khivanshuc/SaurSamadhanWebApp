using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("village")]
    public class VillageModel : IModel
    {
        public long Id { get; set; }
        public long VillageId { get; set; }
        public string VillageName { get; set; }
        public string VillageHindiName { get; set; }
        public long BlockId { get; set; }
        public long DistrictId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

    }

}
