using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("SSYInspectionInProgress/admin/ProjectList")]
    public class VwSSYInspectionInProgressListModel : IModel
    {
        public long Id { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string Village { get; set; }
        public string PlaceorBeneficiaryName { get; set; } // bigint
        public string Project { get; set; } // bigint
        public string SIName { get; set; } // varchar(max)
        public bool IsSystemWorking { get; set; } // bit
        public long StageId { get; set; }
        public bool IsCompleted { get; set; } // bit
        public string UpdatedBy { get; set; } // varchar(max)
        public DateTime UpdatedOn { get; set; } // datetime
    }
}
