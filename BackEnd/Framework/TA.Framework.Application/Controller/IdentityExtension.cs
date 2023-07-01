using System.Security.Claims;
using System.Security.Principal;
using TA.Framework.Core.Constant;

namespace TA.Framework.Application.Controller
{
    public static class IdentityExtension
    {
        public static List<string> GetRole(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimConstant.Role);
            return (claim != null) ? claim.Value.Split(",").ToList() : new List<string>();
        }
    }
}
