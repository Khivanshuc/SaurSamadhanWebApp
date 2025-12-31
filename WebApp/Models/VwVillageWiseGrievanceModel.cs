using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("grievance/site")]
    public class VwVillageWiseGrievanceModel : IModel
    {
        public long Id { get; set; }
        public string FaultRemark { get; set; }
    }
}

