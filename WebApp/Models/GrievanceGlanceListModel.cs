using CredaData.Client;

namespace WebApp.Models;

[ApiMetadata("grievance/admin/GetGrievanceGlanceListAdmin")]

public class GrievanceGlanceListModel:IModel
{
    public long Id { get; set; }
    public int SerialNo { get; set; }
    public string DistrictName { get; set; }
    public string BlockName { get; set; }
    public string VillageName { get; set; }
    public string SiteName { get; set; }
    public string ProjectName { get; set; }
    public string MobileNumber { get; set; }
    public string FaultyRemark { get; set; }

}
