using System.Security.Claims;
using TA.UserAccount.Model.Authentication;
using TA.UserAccount.Model.Request;

namespace TA.UserAccount.RepositoryInterface
{
    public interface IJwtTokenManagerRepository
    {
        Token GenerateToken(TokenRequest model);
        
        Token GenerateRefreshToken(TokenRequest model);

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
