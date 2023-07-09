using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TA.Framework.Repository;
using TA.UserAccount.DataAccess.Application;
using TA.UserAccount.Dto;
using TA.UserAccount.RepositoryInterface;

namespace TA.UserAccount.Repository
{
    public class UserRefreshTokenRepository : BaseRepository<ApplicationContext, ComUserRefreshToken, UserRefreshTokenDto, string>, IUserRefreshTokenRepository
    {
        public UserRefreshTokenRepository(ApplicationContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<UserRefreshTokenDto> ReadByUserUuidAsync(string userUuid)
        {
            var dbSet = this.Context.Set<ComUserRefreshToken>();
            var entity = await dbSet
                .FirstOrDefaultAsync(item => item.UserUuid == userUuid);
            if (entity == null)
            {
                return null;
            }

            var dto = new UserRefreshTokenDto();
            EntityToDto(entity, dto);
            return dto;
        }
    }
}
