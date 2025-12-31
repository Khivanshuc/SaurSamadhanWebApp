using CredaData.Client;

namespace WebApp.Models
{
    [ApiMetadata("ssyPaymentMaster")]
    public class SSYPaymentMasterModel : IModel
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public long CasteId { get; set; }
        public long PumpCapacityId { get; set; }
        public long SolarPumpId { get; set; }
        public long PumpChoiceId { get; set; }
        public string SystemCost { get; set; }
        public string AmountWithGST { get; set; }
        public string StateGrant { get; set; }
        public string CentralGrant { get; set; }
        public string ApplicantCostToBePaidByUser { get; set; }
        public string ApplicationCost { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }
}