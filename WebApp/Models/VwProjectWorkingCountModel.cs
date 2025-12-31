using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("project/ProjectDetailwithCount")]
    public class VwProjectWorkingCountModel : IModel
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public string ProjectName { get; set; }
        public long WorkingProjectCount { get; set; }
        public long NonWorkingProjectCount { get; set; }

    }

}
