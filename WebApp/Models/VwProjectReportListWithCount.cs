using CredaData.Client;

namespace WebApp.Models
{
    public class VwProjectReportListWithCount : IModel
    {
        public long Id { get; set; }
        public string AreaName { get; set; }
        public int BioGasProjectCount { get; set; }
        public int JJMProjectCount { get; set; }
        public int OtherThanJJMProjectCount { get; set; }

        public int SSYProjectCount { get; set; }
        public int CMYojnaProjectCount { get; set; }
        public int CommunityIrrigationProjectCount { get; set; }

        public int RVEDDProjectCount { get; set; }
        public int OtherRVEDDProjectCount { get; set; }
        public int OnGridProjectCount { get; set; }


        public int HighMastProjectCount { get; set; }
        public int MiniMastProjectCount { get; set; }

        public int TotalProjectCount { get; set; }
        // Add more project types as needed

        // Add total model to include project-wise total count
        public int BioGasProjectTotal { get; set; }
        public int JJMProjectTotal { get; set; }
        public int OtherThanJJMProjectTotal { get; set; }
        public int SSYProjectTotal { get; set; }
        public int CMYojnaProjectTotal { get; set; }
        public int CommunityIrrigationProjectTotal { get; set; }
        public int RVEDDProjectTotal { get; set; }
        public int OtherRVEDDProjectTotal { get; set; }
        public int OnGridProjectTotal { get; set; }
        public int HighMastProjectTotal { get; set; }
        public int MiniMastProjectTotal { get; set; }
        public int GrandTotalProjectCount { get; set; }

    }
}
