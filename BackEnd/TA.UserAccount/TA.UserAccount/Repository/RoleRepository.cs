using AutoMapper;
using TA.Framework.Repository;
using TA.UserAccount.DataAccess.Application;
using TA.UserAccount.Dto;
using TA.UserAccount.RepositoryInterface;

namespace TA.UserAccount.Repository
{
    public class RoleRepository : BaseRepository<ApplicationContext, ComRole, RolesDto, string>, IRoleRepository
    {
        public RoleRepository(ApplicationContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
    }
}
