using TA.Framework.ServiceInterface;
using TA.Framework.ServiceInterface.Request;
using TA.Framework.ServiceInterface.Response;
using TA.UserAccount.Dto;
using TA.UserAccount.Model.Authentication;
using TA.UserAccount.Model.Request;

namespace TA.UserAccount.ServiceInterface
{
    public interface IUserAccountService : IBaseService<UserAccountDto, string>
    {
        #region Public Async

        Task<GenericResponse<UserAccountDto>> ReadUserByEmailAddressAsync(string emailAddress);

        Task<GenericResponse<bool>> IsEmailExistAsync(string emailAddress);

        Task<GenericResponse<UserAccountDto>> ReadUserByRefreshTokenAsync(string refreshToken);

        #endregion

        #region Public Sync

        GenericResponse<Token> GenerateToken(TokenRequest request);

        #endregion
    }
}
