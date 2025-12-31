using CredaData.Client;

namespace WebApp.Models;

[ApiMetadata("grievance/admin/GetGrievanceGlanceCount")]

public class GrievanceGlanceCountModel : IModel
{
    public long Id { get; set; }
    public int SerialNo { get; set; }
    public long DistrictId { get; set; }
    public string DistrictName { get; set; }
    public int TotalGrievances { get; set; }
    public int ResolvedGrievances { get; set; }
    public int PendingLessThan30Days { get; set; }
    public int PendingMoreThan30Days { get; set; }
    public int TotalPendingGrievances { get; set; }
    public int PendingDOLessThan30Days { get; set; } // District Officer pending < 30 days
    public int PendingZOLessThan30Days { get; set; } // District Officer pending < 30 days
    public int PendingHOLessThan30Days { get; set; } // Head Office pending < 30 days
    public int PendingDOMoreThan30Days { get; set; } // District Officer pending >= 30 days
    public int PendingZOMoreThan30Days { get; set; } // District Officer pending >= 30 days
    public int PendingHOMoreThan30Days { get; set; }
}