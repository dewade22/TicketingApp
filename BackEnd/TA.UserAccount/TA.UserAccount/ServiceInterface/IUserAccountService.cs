using TA.Framework.ServiceInterface;
using TA.Framework.ServiceInterface.Response;
using TA.UserAccount.Dto;
using TA.UserAccount.Model.Authentication;
using TA.UserAccount.Model.Request;

namespace TA.UserAccount.ServiceInterface
{
    public interface IUserAccountService : IBaseService<UserAccountDto, string>
    {
        Task<GenericResponse<UserAccountDto>> ReadUserByEmailAddressAsync(string emailAddress);

        Task<GenericResponse<bool>> IsEmailExistAsync(string emailAddress);

        GenericResponse<Token> GenerateToken(TokenRequest request);
    }
}
