using CredaData.Client;

namespace WebApp.Models;

[ApiMetadata("user/UserListByZonal")]

public class UserListByZonalModel:IModel
{
    public long Id { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
    public long DistrictId { get; set; }
    public long BlockId { get; set; }
}
