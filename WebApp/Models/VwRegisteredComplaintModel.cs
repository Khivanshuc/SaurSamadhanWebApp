using CredaData.Client;

namespace WebApp.Models;

[ApiMetadata("complaintRegister/admin")]

public class VwRegisteredComplaintModel : IModel
{
    public long Id { get; set; }
    public string ComplaintNumber { get; set; }
    public string UserName { get; set; }
    public long SIId { get; set; }
    public string SIName { get; set; }
    public long DistrictId { get; set; }
    public string DistrictName { get; set; }
    public long BlockId { get; set; }
    public string BlockName { get; set; }
    public long VillageId { get; set; }
    public string VillageName { get; set; }
    public long SiteId { get; set; }
    public string SiteName { get; set; }
    public string ComplaintStatus { get; set; }
    public string ComplaintRemark { get; set; }
    public DateTime? ComplaintDate { get; set; }
    public string AssignedDate { get; set; }
    public string ExpectedDate { get; set; }
    public string Remarks { get; set; }

}
