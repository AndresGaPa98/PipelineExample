using System.ComponentModel.DataAnnotations;

namespace Scm.Infrastructure.Authentication
{
    /// <summary>
    /// Claims for authenticated user
    /// </summary>
    public class AuthenticatedUserClaim
    {
        [Required()]
        public string ClaimType { get; set; }

        [Required()]
        public string ClaimValue { get; set; }
    }
}