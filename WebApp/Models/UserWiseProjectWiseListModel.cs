using CredaData.Client;

namespace WebApp.Models;

[ApiMetadata("project/UserWiseProjectWiseList")]

public class UserWiseProjectWiseListModel : IModel
{
    public long Id { get; set; }
    public long SNo { get; set; }
    public long ProjectId { get; set; }
    public string ProjectName { get; set; }
    public string SIName { get; set; }
    public DateTime? InspectionDate { get; set; }
    public string WorkingStatus { get; set; }
    public string DistrictName { get; set; }
    public string BlockName { get; set; }
    public string VillageName { get; set; }
    public string SiteName { get; set; }
    public string FaultRemark { get; set; }

}