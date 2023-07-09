using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TA.Framework.Repository;
using TA.UserAccount.DataAccess.Application;
using TA.UserAccount.Dto;
using TA.UserAccount.RepositoryInterface;

namespace TA.UserAccount.Repository
{
    public class UserInRoleRepository : BaseRepository<ApplicationContext, ComUserInRole, UserInRoleDto, string>, IUserInRoleRepository
    {
        public UserInRoleRepository(ApplicationContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async Task<UserInRoleDto> ReadByUserUuidAsync(string userUuid)
        {
            var dbSet = this.Context.Set<ComUserInRole>();
            var entity = await dbSet
                .FirstOrDefaultAsync(item => item.UserUuid == userUuid);
            if (entity == null)
            {
                return null;
            }

            var dto = new UserInRoleDto();
            EntityToDto(entity, dto);
            return dto;
        }
    }
}
