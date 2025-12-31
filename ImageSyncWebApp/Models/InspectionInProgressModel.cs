using CredaData.Client;

namespace ImageSyncWebApp.Models
{
    [ApiMetadata("inspectioninprogress")]
    public class InspectionInProgressModel : IModel
    {
        public long Id { get; set; }
        public long SiteId { get; set; }
        public long ProjectId { get; set; }
        public long StageId { get; set; }
        public bool IsComplete { get; set; }
        public bool IsFaulty { get; set; }
        public string Remarks { get; set; }
        public string GeoTag { get; set; }
        public byte[] GeoTagImage { get; set; }
        public string GeoTagImageType { get; set; }
        public bool IsUploaded { get; set; }
        public long InspectedBy { get; set; }
        public DateTime InspectedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
