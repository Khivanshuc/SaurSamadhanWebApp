using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("site/List")]
    public class VwSiteModel:IModel
    {
        public long Id { get; set; }
        public long SiteId { get; set; }
        public string SiteName { get; set; }
        public string BlockName { get; set; }
        public string DistrictName { get; set; }
        public string VillageName { get; set; }

       
    }

}
