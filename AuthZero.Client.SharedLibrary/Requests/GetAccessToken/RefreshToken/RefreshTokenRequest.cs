using AuthZero.Client.SharedLibrary.Common.Constants;

namespace AuthZero.Client.SharedLibrary.Requests.GetAccessToken.RefreshToken
{
    public class RefreshTokenRequest
    {
#nullable disable
        public string ClientId { get; set; }
        public string RefreshToken { get; set; }
        private readonly string grantType;
        public string GrantType
        {
            get
            {
                return grantType;
            }
        }
#nullable enable

        public RefreshTokenRequest()
        {
            grantType = GrantTypes.RefreshToken;
        }
    }
}
