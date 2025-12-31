using CredaData.Client;

namespace WebApp.Models;

[ApiMetadata("user/List")]
public class VwUserModel : IModel
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }      
    public string MobileNumber { get; set; }
    public long RoleId { get; set; }
    public string OfficeLevel { get; set; }
    public string RoleName { get; set; }
    public long DistrictId { get; set; }
    public string DistrictName { get; set; }
    public long BlockId { get; set; }
    public string BlockName { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime UpdatedOn { get; set; }
    public long ZonalId { get; set; }
    public bool IsDistrictIncharge { get; set; }

}
