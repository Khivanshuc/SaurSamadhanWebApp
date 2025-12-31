namespace WebApp.Models
{
    public class AnalyticsModel
    {
        public long TotalMonitoredSystem { get; set; }
        public long TotalWorkingSystems { get; set; }
        public long FaultySystems { get; set; }
        public int TotalGrievances { get; set; }
        public long TotalReportSubmission { get; set; }
    }
}

