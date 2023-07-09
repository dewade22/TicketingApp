using TA.Framework.ServiceInterface;
using TA.Framework.ServiceInterface.Response;
using TA.UserAccount.Dto;

namespace TA.UserAccount.ServiceInterface
{
    public interface IUserInRoleService : IBaseService<UserInRoleDto, string>
    {
        Task<GenericResponse<UserInRoleDto>> ReadByUserUuidAsync(string userUuid);
    }
}
