using CredaData.Client;

namespace WebApp.Models;

[ApiMetadata("complaintRegister/admin/complaintList")]

public class VwComplaintListModel : IModel
{
    public long SerialNo { get; set; }
    public long Id { get; set; }
    public string ComplaintNumber { get; set; }
    public long UserId { get; set; }
    public string SIName { get; set; }
    public string DistrictName { get; set; }
    public string BlockName { get; set; }
    public string VillageName { get; set; }
    public string SiteName { get; set; }
    public string ComplaintStatus { get; set; }
    public DateTime? ComplaintDate { get; set; }

}
