using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("complaintRegister/admin/complaintListNotification")]
    public class ComplaintListNotificationModel : IModel
    {
        public long SerialNo { get; set; }
        public long Id { get; set; }
        public string ComplaintNumber { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public string ComplaintRemark { get; set; }

        public DateTime? ComplaintDate { get; set; }
    }
}