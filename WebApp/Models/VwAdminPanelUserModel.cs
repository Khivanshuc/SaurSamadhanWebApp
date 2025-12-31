using CredaData.Client;

namespace CredaData.Common.Model
{
    [ApiMetadata("AdminPaneluser/admin")]
    public class VwAdminPanelUserModel :IModel
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string District { get; set; }
        public bool? IsActive { get; set; }
        public string Role { get; set; }
        public string OfficeLevel { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }   
}       
        
        
        
        
        
        
        
        
        