namespace WebApp.Models
{
    public class UserVwModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public long RoleId { get; set; }
        public long DistrictId { get; set; }
        public long BlockId { get; set; }
        public long ZonalId { get; set; }
    }
}
