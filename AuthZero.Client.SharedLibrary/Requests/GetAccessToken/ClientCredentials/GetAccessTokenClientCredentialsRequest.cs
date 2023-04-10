using AuthZero.Client.SharedLibrary.Common.Constants;

namespace AuthZero.Client.SharedLibrary.Requests.GetAccessToken.ClientCredentials
{
    public class GetAccessTokenClientCredentialsRequest
    {
#nullable disable
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Audience { get; set; }
        private readonly string grantType;
        public string GrantType
        {
            get
            {
                return grantType;
            }
        }
#nullable enable

        public GetAccessTokenClientCredentialsRequest()
        {
            grantType = GrantTypes.Password;
        }
    }
}
