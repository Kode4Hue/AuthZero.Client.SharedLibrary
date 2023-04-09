using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthZero.Client.SharedLibrary.Requests.GetAccessToken.RefreshToken
{
    public class RefreshTokenRequest
    {
#nullable disable
        public string ClientId { get; set; }
        public string RefreshToken { get; set; }
#nullable enable
    }
}
