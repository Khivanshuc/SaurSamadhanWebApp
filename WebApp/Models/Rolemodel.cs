using CredaData.Client;

namespace WebApp.Models;

[ApiMetadata("role")]

public class RoleModel :IModel
{
    public long Id { get; set; }
    public string RoleName { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime UpdatedOn { get; set; }

}
