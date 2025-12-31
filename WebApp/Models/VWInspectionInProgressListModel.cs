using CredaData.Client;

namespace WebApp.Models
{
    //[ApiMetadata("inspectioninprogress/List")]
    [ApiMetadata("inspectioninprogress/admin/ProjectList")]
    public class VWInspectionInProgressListModel :IModel
    {
        //public long Id { get; set; }
        //public string DistrictName { get; set; }
        //public string BlockName { get; set; }
        //public string SiteName { get; set; }
        //public string ProjectName { get; set; }
        //public string StageName { get; set; }
        //public bool IsComplete { get; set; }
        //public DateTime InspectedOn { get; set; }
        //public string UpdatedBy { get; set; }
        //public DateTime UpdatedOn { get; set; }

        public long Id { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public string VillageName { get; set; }
        public string SiteName { get; set; }
        public string ProjectName { get; set; }
        public string StageName { get; set; }
        public bool IsComplete { get; set; }
        public string IsFaulty { get; set; }
        public DateTime InspectedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
}
