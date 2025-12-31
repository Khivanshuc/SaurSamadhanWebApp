using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("zonal")]
    public class ZonalModel : IModel
    {
        public long Id { get; set; }
        public string ZonalOffices { get; set; }
    }

}
