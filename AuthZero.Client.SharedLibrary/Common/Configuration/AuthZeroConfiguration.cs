namespace AuthZero.Client.SharedLibrary.Common.Configuration
{
    public class AuthZeroConfiguration
    {
#nullable disable
        public string BaseAddress { get; set; }
        public string ApiVersion { get; set; }
        public string ApiPath { get; set; }
        public AuthZeroClient Client { get; set; }
        public string Connection { get; set; }
        public bool ShouldLogHttpRequest { get; set; }
#nullable enable
    }
}
