namespace AuthZero.Client.SharedLibrary.Requests.CreateAUser
{
    public class CreateAUserRequest
    {
#nullable disable
        public string Connection { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public dynamic UserMetadata { get; set; }
        public bool EmailVerified { get; set; }
        public dynamic AppMetadata { get; set; }
#nullable enable
    }
}
