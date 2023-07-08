using TA.Framework.Service;
using TA.UserAccount.Dto;
using TA.UserAccount.RepositoryInterface;
using TA.UserAccount.ServiceInterface;

namespace TA.UserAccount.Service
{
    public class UserRefreshTokenService : BaseService<UserRefreshTokenDto, string, IUserRefreshTokenRepository>, IUserRefreshTokenService
    {
        public UserRefreshTokenService(IUserRefreshTokenRepository repository)
            : base(repository)
        {

        }
    }
}
