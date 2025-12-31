using CredaData.Client;

namespace WebApp.Models;

[ApiMetadata("CommunityIrrigationAlreadyCompleted/admin/ProjectList")]

public class VwCIAlreadyCompletedListModel : IModel
{
    public long Id { get; set; } // bigint
    public string District { get; set; }
    public string Block { get; set; }
    public string Village { get; set; }
    public string Site { get; set; } // bigint
    public string Project { get; set; } // bigint
    public string SIName { get; set; } // varchar(max)
    public bool IsSystemWorking { get; set; } // bit
    public string UpdatedBy { get; set; } // varchar(max)
    public DateTime UpdatedOn { get; set; } // datetime
}
