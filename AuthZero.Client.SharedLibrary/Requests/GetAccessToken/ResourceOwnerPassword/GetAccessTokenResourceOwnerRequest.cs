using AuthZero.Client.SharedLibrary.Common.Constants;

namespace AuthZero.Client.SharedLibrary.Requests.GetAccessToken.ResourceOwnerPassword
{
    public class GetAccessTokenResourceOwnerRequest
    {
#nullable disable
        public string Username { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        //public string ClientSecret { get; set; }
        //public string Audience { get; set; }

        private readonly string grantType;
        public string GrantType { get
            {
                return grantType;
            }
        }
#nullable enable

        public GetAccessTokenResourceOwnerRequest()
        {
            grantType = GrantTypes.Password;
        }
    }
}
