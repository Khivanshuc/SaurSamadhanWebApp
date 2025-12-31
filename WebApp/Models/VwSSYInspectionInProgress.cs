using CredaData.Client;

namespace WebApp.Models
{
    public class VwSSYInspectionInProgress 
    {
        public long Id { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public string VillageName { get; set; }
        public string ProjectName { get; set; }
        public string PhaseName { get; set; }
        public string PlaceorBeneficiaryName { get; set; }
        public string PlaceorBeneficiaryId { get; set; }
        public string StageName { get; set; }
        public bool IsComplete { get; set; }
        public bool IsFaulty { get; set; }
        public string Remarks { get; set; }
        public string GeoTag { get; set; }
        public string GeoTagImage { get; set; }
        public string GeoTagImageType { get; set; }
        public bool IsUploaded { get; set; }
        public string InspectedBy { get; set; }
        public DateTime? InspectedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
