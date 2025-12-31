using CredaData.Client;

namespace WebApp.Models;

[ApiMetadata("user")]

public class UserModel :IModel
{
    public long Id { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public long RoleId { get; set; }
    public long DistrictId { get; set; }
    public long BlockId { get; set; }
    public long ZonalId { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime UpdatedOn { get; set; }
    public string ApiKey { get; set; }
    public string Password { get; set; }
    public bool IsActive { get; set; }
    public long IsDistrictIncharge { get; set; }

}
