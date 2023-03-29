namespace AuthZero.Client.SharedLibrary.Requests.GetAccessToken.ResourceOwnerPassword
{
    public class GetAccessTokenResourceOwnerRequest
    {
#nullable disable
        public string Username { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        //public string ClientSecret { get; set; }
        public string Audience { get; set; }
        public string GrantType { get; set; }
#nullable enable
    }
}
