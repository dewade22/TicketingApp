using TA.Framework.Service;
using TA.UserAccount.Dto;
using TA.UserAccount.RepositoryInterface;
using TA.UserAccount.ServiceInterface;

namespace TA.UserAccount.Service
{
    public class RoleService : BaseService<RolesDto, string, IRoleRepository>, IRoleService
    {
        public RoleService(IRoleRepository repository)
            : base(repository)
        {

        }
    }
}
