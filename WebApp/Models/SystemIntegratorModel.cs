using CredaData.Client;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    [ApiMetadata("SystemIntegrator")]
    public class SystemIntegratorModel :IModel
    {
        public long Id { get; set; }
        public long SIID { get; set; }
        public string SIName { get; set; }
        public string SIAddress { get; set; }
        public string SIContactPerson { get; set; }
        public string SIMobile { get; set; }
        public string SIEmail { get; set; }
        public string SICategory { get; set; }

    }
}

