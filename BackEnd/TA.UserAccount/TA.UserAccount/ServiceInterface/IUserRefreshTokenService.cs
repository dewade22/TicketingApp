using TA.Framework.ServiceInterface;
using TA.Framework.ServiceInterface.Response;
using TA.UserAccount.Dto;

namespace TA.UserAccount.ServiceInterface
{
    public interface IUserRefreshTokenService : IBaseService<UserRefreshTokenDto, string>
    {
        Task<GenericResponse<UserRefreshTokenDto>> ReadByUserUuidAsync(string userUuid);
    }
}
