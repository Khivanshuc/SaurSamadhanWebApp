using CredaData.Client;

namespace WebApp.Models;

[ApiMetadata("grievance")]

public class GrievanceAnalyticsDataModel: IModel
{
    public long Id { get; set; }
    public long DistrictId { get; set; }
    public string DistrictName { get; set; }
    public int TotalGrievances { get; set; }
    public int Pending { get; set; }
    public int Resolved { get; set; }
}
