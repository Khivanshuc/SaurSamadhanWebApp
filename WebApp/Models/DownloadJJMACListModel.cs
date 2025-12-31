using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("jjmalreadycompleted/admin/JJMDownloadProjectList")]
    public class DownloadJJMACListModel : IModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string District { get; set; }
        public string Block { get; set; }
        public string Village { get; set; }
        public string Site { get; set; }
        public string Project { get; set; }
        public DateTime InspectionDate { get; set; }
        public string SystemName { get; set; }
        public string SIName { get; set; }
        public string IsSystemWorking { get; set; } 
        public string IsSystemWorkingRemark { get; set; }
        public string IsPumpWorking { get; set; } 
        public string IsControllerWorking { get; set; } 
        public string SystemLayout { get; set; }
        public string PanelMake { get; set; }
        public string IsPipelineWorking { get; set; } 
        public string IsOHTWorking { get; set; } 
        public string TotalDepth { get; set; }
        public string SystemWorkingDuration { get; set; }
        public string TechnicalFaultRemark { get; set; }
        public string AnyOtherRemarks { get; set; }
        public string ImageWithFunctionality { get; set; }
        public string ImageWithCompleteSystem { get; set; }
        public string ImageMangpatra { get; set; }
        public string GeoTag { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
