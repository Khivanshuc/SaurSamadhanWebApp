using CredaData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
    [ApiMetadata("grievance/admin/GetGrievanceList")]
    public class VwGrievanceListModel :IModel
    {
        public long Id { get; set; }
        public string GrievanceStatus { get; set; }
        public string DistrictName { get; set; }
        public string BlockName { get; set; }
        public string ProjectName { get; set; }
        public string FaultRemark { get; set; }
        public string? AssignTo { get; set; }
        public bool? IsActive { get; set; }
        public string EntryType { get; set; }
    }
}
