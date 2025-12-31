using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("inspectioninprogress/admin/IPDownloadProjectList")]
    public class DownloadInspectionIPListModel : IModel
    {
        public long Id { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public string VillageName { get; set; }
        public string SiteName { get; set; }
        public string ProjectName { get; set; }
        public string StageName { get; set; }
        public string IsComplete { get; set; }
        public string IsFaulty { get; set; }
        public string Remarks { get; set; }
        public string GeoTag { get; set; }
        public byte[] GeoTagImage { get; set; }
        public string GeoTagImageBase64 { get; set; }
        public string GeoTagImageType { get; set; }
        public string InspectedBy { get; set; }
        public DateTime InspectedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
