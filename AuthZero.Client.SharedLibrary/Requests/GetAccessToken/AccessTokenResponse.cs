namespace AuthZero.Client.SharedLibrary.Requests.GetAccessToken
{
    public class AccessTokenResponse
    {
#nullable disable
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }

#nullable enable

        public string? RefreshToken { get; set; }
        public string? IdToken { get; set; }
        public string? Scope { get; set; }
    }
}
