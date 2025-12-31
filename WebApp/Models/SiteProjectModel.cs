using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("siteproject")]
    public class SiteProjectModel : IModel
    {
        public long Id { get; set; }
        public string CSiteId { get; set; }
        public long SiteId { get; set; }
        public long ProjectId { get; set; }
        public string SystemIntegrator { get; set; }
        public string Capacity { get; set; }
        public string InstallationYear { get; set; }
        public string UpdationDate { get; set; }
        public string IsWorking { get; set; }
        public string Remark { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

    }

}
