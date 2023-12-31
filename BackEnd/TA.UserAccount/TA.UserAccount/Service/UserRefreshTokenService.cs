﻿using TA.Framework.Service;
using TA.Framework.ServiceInterface.Response;
using TA.UserAccount.Core.Resource;
using TA.UserAccount.Dto;
using TA.UserAccount.RepositoryInterface;
using TA.UserAccount.ServiceInterface;

namespace TA.UserAccount.Service
{
    public class UserRefreshTokenService : BaseService<UserRefreshTokenDto, string, IUserRefreshTokenRepository>, IUserRefreshTokenService
    {
        public UserRefreshTokenService(IUserRefreshTokenRepository repository)
            : base(repository)
        {

        }

        public async Task<GenericResponse<UserRefreshTokenDto>> ReadByUserUuidAsync(string userUuid)
        {
            var response = new GenericResponse<UserRefreshTokenDto>();

            var result = await this._repository.ReadByUserUuidAsync(userUuid);
            if (result == null)
            {
                response.AddErrorMessage(UserAccountResource.RefreshToken_NotFound);
                return response;
            }

            response.Data = result;

            return response;
        }
    }
}
