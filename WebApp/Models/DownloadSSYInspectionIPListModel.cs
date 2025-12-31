using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("SSYInspectionInProgress/admin/SSYInProgressDownloadProjectList")]
    public class DownloadSSYInspectionIPListModel : IModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public string VillageName { get; set; }
        public string ProjectName { get; set; }
        public string PhaseName { get; set; }
        public string PlaceorBeneficiaryName { get; set; }
        public string PlaceorBeneficiaryId { get; set; }
        public string StageName { get; set; }
        public string IsComplete { get; set; }
        public string IsFaulty { get; set; }
        public string Remarks { get; set; }
        public string GeoTag { get; set; }
        public string GeoTagImage { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
