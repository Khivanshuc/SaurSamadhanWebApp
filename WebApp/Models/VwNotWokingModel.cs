using CredaData.Client;

namespace WebApp.Models;

[ApiMetadata("Project/NotWorking")]
public class VwNotWokingModel : IModel
{
    public long Id { get; set; }
    public long ProjectId { get; set; }
    public string Status { get; set; }
    public string SIName { get; set; }
}


public class VwTestModel : IModel
{
    public DateTime ComDT { get; set; }
    public string Phase { get; set; }
    public long Id { get; set; }
}
public class ABC : IModel
{
    public DateTime ComDT { get; set; }
    public string Phase { get; set; }
    public long Id { get; set; }
}
