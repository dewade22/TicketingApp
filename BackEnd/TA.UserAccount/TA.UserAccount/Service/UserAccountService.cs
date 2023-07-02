using TA.Framework.Service;
using TA.Framework.ServiceInterface.Response;
using TA.UserAccount.Core.Resource;
using TA.UserAccount.Dto;
using TA.UserAccount.RepositoryInterface;
using TA.UserAccount.ServiceInterface;

namespace TA.UserAccount.Service
{
    public class UserAccountService : BaseService<UserAccountDto, string, IUserAccountRepository>, IUserAccountService
    {
        private readonly IJwtTokenManagerRepository _jwtTokenManagerRepository;
        private readonly IUserInRoleRepository _userInRoleRepository;
        private readonly IUserMembershipRepository _userMembershipRepository;
        private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;

        public UserAccountService(
            IUserAccountRepository repository,
            IJwtTokenManagerRepository jwtTokenManagerRepository,
            IUserInRoleRepository userInRoleRepository,
            IUserMembershipRepository userMembershipRepository,
            IUserRefreshTokenRepository userRefreshTokenRepository)
            : base(repository)
        {
            _jwtTokenManagerRepository = jwtTokenManagerRepository;
            _userInRoleRepository = userInRoleRepository;
            _userMembershipRepository = userMembershipRepository;
            _userRefreshTokenRepository = userRefreshTokenRepository;
        }

        #region Public Async

        public async Task<GenericResponse<UserAccountDto>> ReadUserByEmailAddressAsync(string emailAddress)
        {
            var response = new GenericResponse<UserAccountDto>();

            var result = await this._repository.ReadUserByEmailAddress(emailAddress);
            if (result == null)
            {
                response.AddErrorMessage(string.Format(UserAccountResource.UserEmail_NotFound, emailAddress));
                return response;
            }

            response.Data = result;

            return response;
        }

        public async Task<GenericResponse<bool>> IsEmailExistAsync(string emailAddress)
        {
            var response = new GenericResponse<bool>();
            var result = await this._repository.IsEmailExistAsync(emailAddress);

            response.Data = result;

            return response;
        }

        #endregion
    }
}
