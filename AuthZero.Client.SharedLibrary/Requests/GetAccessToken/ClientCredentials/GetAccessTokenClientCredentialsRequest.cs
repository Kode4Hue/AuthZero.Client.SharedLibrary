namespace AuthZero.Client.SharedLibrary.Requests.GetAccessToken.ClientCredentials
{
    public class GetAccessTokenClientCredentialsRequest
    {
#nullable disable
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Audience { get; set; }
        public string GrantType { get; set; }
#nullable enable
    }
}
