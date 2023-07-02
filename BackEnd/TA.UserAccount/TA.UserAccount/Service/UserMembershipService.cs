using TA.Framework.Service;
using TA.UserAccount.Dto;
using TA.UserAccount.RepositoryInterface;
using TA.UserAccount.ServiceInterface;

namespace TA.UserAccount.Service
{
    public class UserMembershipService : BaseService<UserMembershipDto, string, IUserMembershipRepository>, IUserMembershipService
    {
        public UserMembershipService(IUserMembershipRepository repository)
            : base (repository)
        {

        }
    }
}
