using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TA.Framework.Repository;
using TA.UserAccount.DataAccess.Application;
using TA.UserAccount.Dto;
using TA.UserAccount.RepositoryInterface;

namespace TA.UserAccount.Repository
{
    public class UserAccountRepository : BaseRepository<ApplicationContext, ComUserAccount, UserAccountDto, string>, IUserAccountRepository
    {
        public UserAccountRepository(ApplicationContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        #region Public Async
        public async Task<UserAccountDto> ReadUserByEmailAddress(string emailAddress)
        {
            var dbSet = this.Context.Set<ComUserAccount>();
            var entity = await dbSet
                .Include(x => x.ComUserInRoles)
                    .ThenInclude(r => r.RoleUu)
                .Include(x => x.ComUserMemberships)
                .Include(x => x.ComUserRefreshTokens)
                .FirstOrDefaultAsync(item => item.EmailAddress == emailAddress);
            if (entity == null)
            {
                return null;
            }

            var dto = new UserAccountDto();
            EntityToDto(entity, dto);
            return dto;
        }

        public async Task<bool> IsEmailExistAsync(string emailAddress)
        {
            var dbSet = this.Context.Set<ComUserAccount>();
            var entity = await dbSet.FirstOrDefaultAsync(x => x.EmailAddress == emailAddress);

            return entity != null;
        }

        #endregion

        protected override void EntityToDtoWithRelation(ComUserAccount entity, UserAccountDto dto)
        {
            this.Mapper.Map(entity, dto);

            if (entity.ComUserInRoles != null)
            {
                dto.RoleName = entity.ComUserInRoles.Select(u => u.RoleUu.RoleName).FirstOrDefault();
            }

            if (entity.ComUserMemberships != null)
            {
                dto.Password = entity.ComUserMemberships.Select(m => m.Password).FirstOrDefault();
            }

            if (entity.ComUserRefreshTokens != null)
            {
                dto.RefreshToken = entity.ComUserRefreshTokens.Select(r => r.RefreshToken).FirstOrDefault();
            }
        }
    }
}
