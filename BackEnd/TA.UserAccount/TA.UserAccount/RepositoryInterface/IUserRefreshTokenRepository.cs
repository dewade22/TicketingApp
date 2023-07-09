using TA.Framework.RepositoryInterface;
using TA.UserAccount.Dto;

namespace TA.UserAccount.RepositoryInterface
{
    public interface IUserRefreshTokenRepository : IBaseRepository<UserRefreshTokenDto>
    {
        Task<UserRefreshTokenDto> ReadByUserUuidAsync(string userUuid);
    }
}
