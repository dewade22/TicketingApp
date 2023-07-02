using AutoMapper;
using TA.Framework.Repository;
using TA.UserAccount.DataAccess.Application;
using TA.UserAccount.Dto;
using TA.UserAccount.RepositoryInterface;

namespace TA.UserAccount.Repository
{
    public class UserMembershipRepository : BaseRepository<ApplicationContext, ComUserMembership, UserMembershipDto, string>, IUserMembershipRepository
    {
        public UserMembershipRepository(ApplicationContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
    }
}
