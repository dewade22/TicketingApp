﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using TA.Framework.Application.Controller;
using TA.Framework.Application.Model;
using TA.Framework.Core.Constant;
using TA.Framework.Core.Resource;
using TA.Framework.ServiceInterface.Request;
using TA.UserAccount.Core.Resource;
using TA.UserAccount.Dto;
using TA.UserAccount.Helper;
using TA.UserAccount.Model.Authentication;
using TA.UserAccount.Model.Request;
using TA.UserAccount.ServiceInterface;

namespace TA.UserAccount.Controllers
{
    [ApiController]
    [Route("v/{version:apiversion}/[controller]")]
    [ApiVersion("1.0")]
    public class UserAccountController : BaseController
    {
        private readonly IUserAccountService _userAccountService;
        private readonly IUserMembershipService _userMembershipService;

        public UserAccountController(
            IUserAccountService userAccountService,
            IUserMembershipService userMembershipService)
        {
            this._userAccountService = userAccountService;
            this._userMembershipService = userMembershipService;
        }

        [HttpGet]
        [Authorize]
        [Route("/v{version:apiversion}/UserAccount/{emailAddress}")]
        public async Task<IActionResult> ReadUserByEmailAddressAsync([FromRoute][Required] string emailAddress)
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                return this.GetApiError(new[] { UserAccountResource.UserAccount_EmptyEmail }, (int)HttpStatusCode.BadRequest);
            }

            var userAccountResponse = await this._userAccountService.ReadUserByEmailAddressAsync(emailAddress);
            if (userAccountResponse.IsError())
            {
                return this.GetApiError(userAccountResponse.GetMessageErrorTextArray(), (int)HttpStatusCode.NotFound);
            }

            return new OkObjectResult(userAccountResponse.Data);
        }

        [HttpPost]
        [Route("/v{version:apiversion}/UserAccount")]
        public async Task<IActionResult> CreateUserAsync([FromBody]CreateUserRequest model)
        {
            if (ModelState.IsValid)
            {
                if (!this.IsValidTimeZone(model.TimeZoneId))
                {
                    return this.GetApiError(new[] { GeneralResource.Timezone_Invalid }, (int)HttpStatusCode.BadRequest);
                }

                var isEmailAddressExistResponse = await this._userAccountService.IsEmailExistAsync(model.EmailAddress);
                if (isEmailAddressExistResponse.Data)
                {
                    return this.GetApiError(new[] { string.Format(UserAccountResource.CreateUser_EmailExist, model.EmailAddress) }, (int)HttpStatusCode.BadRequest);
                }

                var createUserRequest = new GenericRequest<UserAccountDto>()
                {
                    Data = new UserAccountDto
                    {
                        Uuid = this.GenerateUuid(UidTableConstant.UserAccount),
                        EmailAddress = model.EmailAddress,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        TimeZoneId = model.TimeZoneId,
                        IsArchived = false,
                    }
                };

                this.PopulateCreatedFields(createUserRequest.Data);

                var createUserResponse = await this._userAccountService.InsertAsync(createUserRequest);
                if (createUserResponse.IsError())
                {
                    this.GetApiError(createUserResponse.GetMessageErrorTextArray(), (int)HttpStatusCode.BadRequest);
                }

                var hashedPassword = CryptoHash.HashedString(model.Password);

                var createUserPasswordRequest = new GenericRequest<UserMembershipDto>()
                {
                    Data = new UserMembershipDto()
                    {
                        Uuid = this.GenerateUuid(UidTableConstant.UserMembership),
                        UserUuid = createUserRequest.Data.Uuid,
                        Password = hashedPassword,
                    }
                };

                this.PopulateCreatedFields(createUserPasswordRequest.Data);

                var createUserPasswordResponse = await this._userMembershipService.InsertAsync(createUserPasswordRequest);
                if (createUserPasswordResponse.IsError())
                {
                    await this._userAccountService.DeleteAsync(new GenericRequest<string> { Data = createUserRequest.Data.Uuid });
                    return this.GetApiError(createUserPasswordResponse.GetMessageErrorTextArray(), (int)HttpStatusCode.BadRequest);
                }

                var apiResponse = new BasicApiResponse()
                {
                    Uuid = createUserResponse.Data.Uuid,
                };

                return this.Created("/Home/Index", apiResponse);
            }

            return this.GetApiError(new[] { GeneralResource.General_RequestInvalid }, (int)HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [Route("/v{version:apiversion}/UserAccount/SignIn")]
        public async Task<IActionResult> SignIn([FromBody]LoginRequest model)
        {
            if (!ModelState.IsValid)
            {
                return this.GetApiError(new[] { GeneralResource.General_RequestInvalid }, (int)HttpStatusCode.BadRequest);
            }

            var userResponse = await this._userAccountService.ReadUserByEmailAddressAsync(model.Email);
            if (userResponse.IsError())
            {
                return this.GetApiError(new[] { UserAccountResource.User_NotRegistered }, (int)HttpStatusCode.BadRequest);
            }

            if (userResponse.Data.IsArchived)
            {
                return this.GetApiError(new[] { UserAccountResource.User_Archived }, (int)HttpStatusCode.BadRequest);
            }

            var isPasswordMatch = CryptoHash.Verify(model.Password, userResponse.Data.Password);

            if (!isPasswordMatch)
            {
                return this.GetApiError(new[] { UserAccountResource.User_WrongPassword }, (int)HttpStatusCode.BadRequest);
            }

            var tokenRequest = new TokenRequest()
            {
                UserUuid = userResponse.Data.Uuid,
                EmailAddress = model.Email,
                Role = userResponse.Data.RoleName ?? string.Empty,
            };
            
            var tokenResponse = this._userAccountService.GenerateToken(tokenRequest);
            if (tokenResponse.IsError())
            {
                return this.GetApiError(tokenResponse.GetMessageErrorTextArray(), (int)HttpStatusCode.BadRequest);
            }

            return new OkObjectResult(tokenResponse);
        }
    }
}
