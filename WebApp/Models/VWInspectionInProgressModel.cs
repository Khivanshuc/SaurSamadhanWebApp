using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("inspectioninprogress/Id")]
    public class VWInspectionInProgressModel : IModel
    {
        public long Id { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public string SiteName { get; set; }
        public string ProjectName { get; set; }
        public string StageName { get; set; }
        public bool IsComplete { get; set; }
        public bool IsFaulty { get; set; }
        public string Remarks { get; set; }
        public string GeoTag { get; set; }
        public byte[] GeoTagImage { get; set; }
        public string GeoTagImageBase64 { get; set; }
        public string GeoTagImageType { get; set; }
        public bool IsUploaded { get; set; }
        public string InspectedBy { get; set; }
        public DateTime InspectedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }

}
