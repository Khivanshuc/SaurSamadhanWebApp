using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("project")]
    public class ProjectModel : IModel
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public string ProjectName { get; set; }
        public long? ParentId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }

}
