using CredaData.Client;

namespace WebApp.Models;

[ApiMetadata("AdminPaneluser")]

public class AdminPanelUserModel : IModel
{
    public long Id { get; set; }
    public long? UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public long? DistrictId { get; set; }
    public bool? IsActive { get; set; }
    public long? RoleId { get; set; }
    public long? ZonalId { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }

}
