using CredaData.Client;

namespace ImageSyncWebApp.Models
{
    [ApiMetadata("jjmalreadycompleted")]
    public class VWJJMAlreadyCompletedModel : IModel
    {
        public long Id { get; set; } // bigint
        public long UserId { get; set; } // bigint
        public long DistrictId { get; set; } // bigint
        public long BlockId { get; set; } // bigint
        public long VillageId { get; set; } // bigint
        public long SiteId { get; set; } // bigint
        public long ProjectId { get; set; } // bigint
        public DateTime InspectionDate { get; set; } // datetime
        public string SystemName { get; set; } // varchar(max)
        public string SIName { get; set; } // varchar(max)
        public bool IsSystemWorking { get; set; } // bit
        public string IsSystemWorkingRemark { get; set; } // varchar(max)
        public bool IsPumpWorking { get; set; } // bit
        public bool IsControllerWorking { get; set; } // bit
        public string SystemLayout { get; set; } // varchar(max)
        public string PanelMake { get; set; } // varchar(max)
        public bool IsPipelineWorking { get; set; } // bit
        public bool IsOHTWorking { get; set; } // bit
        public string TotalDepth { get; set; } // varchar(max)
        public string SystemWorkingDuration { get; set; } // varchar(max)
        public string TechnicalFaultRemark { get; set; } // varchar(max)
        public string AnyOtherRemarks { get; set; } // varchar(max)
        public byte[] ImageWithFunctionality { get; set; } // varbinary(max)
        public string ImageWithFunctionalityType { get; set; } // varchar(max)
        public byte[] ImageWithCompleteSystem { get; set; } // varbinary(max)
        public string ImageWithCompleteSystemType { get; set; } // varchar(max)
        public byte[] ImageMangpatra { get; set; } // varbinary(max)
        public string ImageMangpatraType { get; set; } // varchar(max)
        public string GeoTag { get; set; } // varchar(max)
        public string UpdatedBy { get; set; } // varchar(max)
        public DateTime UpdatedOn { get; set; } // datetime
        public bool IsUploaded { get; set; } // bit
    }
}
