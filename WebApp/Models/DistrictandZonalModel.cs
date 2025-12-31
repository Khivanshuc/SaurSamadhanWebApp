using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("districtzonal")]
    public class DistrictandZonalModel : IModel
    {
        public long Id { get; set; }
        public long ZonalId { get; set; }
        public long DistrictId { get; set; }
    }

}
