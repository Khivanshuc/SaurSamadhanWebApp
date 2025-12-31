using CredaData.Client;

namespace WebApp.Models;

[ApiMetadata("bankDetail")]

public class BankDetailModel : IModel
{
    public long Id { get; set; }
    public long? ProjectId { get; set; }
    public long? RegistrationId { get; set; }
    public string AccountNumber { get; set; }
    public string BankName { get; set; }
    public string IFSCCode { get; set; }
    public string DDReceiptNumber { get; set; }
    public string DDBankName { get; set; }
    public DateTime? Date { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }


}
