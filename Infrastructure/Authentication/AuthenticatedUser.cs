using System.Collections.Generic;

namespace Scm.Infrastructure.Authentication
{
    /// <summary>
    /// Class for authenticated user information
    /// </summary>
    public class AuthenticatedUser
    {
        public AuthenticatedUser() : base()
        {
            UserName = "Not authorized";
            AccessToken = string.Empty;
        }
        public string UserName { get; set; }

        public bool IsAuthenticated { get; set; }

        public List<AuthenticatedUserClaim> Claims { get; set; }

        public string AccessToken { get; set; }

        public string EncryptedAccessToken { get; set; }

        public int ExpireInSeconds { get; set; }

        public string UserId { get; set; }
    }
}