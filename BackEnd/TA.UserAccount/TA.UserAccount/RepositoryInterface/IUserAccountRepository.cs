using TA.Framework.RepositoryInterface;
using TA.UserAccount.Dto;

namespace TA.UserAccount.RepositoryInterface
{
    public interface IUserAccountRepository : IBaseRepository<UserAccountDto>
    {
        Task<UserAccountDto> ReadUserByEmailAddress(string emailAddress);

        Task<bool> IsEmailExistAsync(string emailAddress);

        Task<UserAccountDto> ReadUserByRefreshTokenAsync(string refreshToken);
    }
}
