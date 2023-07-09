using TA.Framework.Service;
using TA.Framework.ServiceInterface.Response;
using TA.UserAccount.Core.Resource;
using TA.UserAccount.Dto;
using TA.UserAccount.RepositoryInterface;
using TA.UserAccount.ServiceInterface;

namespace TA.UserAccount.Service
{
    public class UserInRoleService : BaseService<UserInRoleDto, string, IUserInRoleRepository>, IUserInRoleService
    {
        public UserInRoleService(IUserInRoleRepository repository)
            : base(repository)
        {
        }

        public async Task<GenericResponse<UserInRoleDto>> ReadByUserUuidAsync(string userUuid)
        {
            var response = new GenericResponse<UserInRoleDto>();

            var result = await this._repository.ReadByUserUuidAsync(userUuid);
            if (result == null)
            {
                response.AddErrorMessage(UserAccountResource.UserInRole_NotFound);
                return response;
            }

            response.Data = result;

            return response;
        }
    }
}
