namespace CredaData.Client
{
    public class ApiMetadataAttribute: Attribute
    {
        public ApiMetadataAttribute(string apiPath) 
        {
            ApiPath = apiPath;
        }

        public string ApiPath { get; }
    }
}
