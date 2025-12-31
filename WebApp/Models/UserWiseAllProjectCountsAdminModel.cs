using CredaData.Client;

namespace WebApp.Models;

[ApiMetadata("project/UserListWithProjectCount")]

public class UserWiseAllProjectCountsAdminModel :IModel
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public long DistrictId { get; set; }
    public string DistrictName { get; set; }
    public int BioGasProjectCount { get; set; }
    public int JJMProjectCount { get; set; }
    public int OtherThanJJMProjectCount { get; set; }
    public int SSYProjectCount { get; set; }
    public int CMYojnaProjectCount { get; set; }
    public int CommunityIrrigationProjectCount { get; set; }
    public int RVEDDProjectCount { get; set; }
    public int OtherRVEDDProjectCount { get; set; }
    public int OnGridProjectCount { get; set; }
    public int HighMastProjectCount { get; set; }
    public int MiniMastProjectCount { get; set; }
    public int TotalProjectCount { get; set; }


}
