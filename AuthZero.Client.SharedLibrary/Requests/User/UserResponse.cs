using AuthZero.Client.SharedLibrary.Common.User;

namespace AuthZero.Client.SharedLibrary.Requests.User
{
    public class UserResponse
    {
#nullable disable
        public string UserId { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public UserMetadata UserMetadata { get; set; }
#nullable enable
    }
}
