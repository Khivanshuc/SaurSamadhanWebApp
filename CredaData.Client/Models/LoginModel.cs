using CredaData.Client;

namespace CredaData.Models;
[ApiMetadata("LoginMobile")]

public class LoginModel : IModel
{
    public long Id { get; set; }
    public string DeviceUniqueKey { get; set; }
    public string MobileNumber { get; set; }
    public string Otp { get; set; }

}

