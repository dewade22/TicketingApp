using TA.Framework.ServiceInterface;
using TA.UserAccount.Dto;

namespace TA.UserAccount.ServiceInterface
{
    public interface IUserRefreshTokenService : IBaseService<UserRefreshTokenDto, string>
    {
    }
}
