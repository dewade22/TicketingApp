using AutoMapper;
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
    }
}
