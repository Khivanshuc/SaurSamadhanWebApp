using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSyncApplication.Models
{
    public class DistrictModel
    {
        public long Id { get; set; }
        public long DistrictId { get; set; }
        public string DistrictName { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
