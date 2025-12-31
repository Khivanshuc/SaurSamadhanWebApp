using CredaData.Client;

namespace CredaData.Models;

[ApiMetadata("user")]
public class AutoCompleteModel : IModel
{

    public long Id { get; set; } // varchar(100)
    public string Name { get; set; } // varchar(100)
    public string Email { get; set; } // varchar(100)
    public string MobileNumber { get; set; } // varchar(100)
    public string Gender { get; set; } // varchar(45)
    public string Designation { get; set; } // varchar(100)
    public long ReportingTo { get; set; } // bigint
    public string WhatsappNumber { get; set; } // varchar(255)
    public string TelegramNumber { get; set; } // varchar(255)
    public string FacebookProfile { get; set; } // varchar(255)
    public string BoothName { get; set; } // varchar(255)
    public string FacebookToken { get; set; } // varchar(500)
    public string InstagramProfile { get; set; } // varchar(255)
    public string InstagramToken { get; set; } // varchar(500)
    public string TwitterProfile { get; set; } // varchar(255)
    public string TwitterToken { get; set; } // varchar(500)

    //public string ReportingToName { get; set; } // bigint
}