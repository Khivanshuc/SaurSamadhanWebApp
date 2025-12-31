using CredaData.Client;

namespace WebApp.Models;

public class ShowProjectReportModel : IModel
{
    public long Id { get; set; }
    public long SNo { get; set; }
    public string ProjectName { get; set; }
    public string DistrictName { get; set; }
    public string BlockName { get; set; }
    public string VillageName { get; set; }
    public string SiteName { get; set; }
    public string SIName { get; set; }
    public string InspectionDoneBy { get; set; }
    public DateTime? InspectionDate { get; set; }
    public string WorkingStatus { get; set; }
    public string FaultyRemark { get; set; }

}
