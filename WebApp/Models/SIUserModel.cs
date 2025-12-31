using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("SIUser")]
    public class SIUserModel : IModel
    {
        public long Id { get; set; }
        public long? SIId { get; set; }
        public string SIName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public long? OTP { get; set; }
        public string APIKey { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string SIContactPerson { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}
