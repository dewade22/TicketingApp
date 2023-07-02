using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TA.Framework.Application.Model;
using TA.Framework.Dto;
using TA.Framework.ServiceInterface.Response;

namespace TA.Framework.Application.Controller
{
    public abstract class BaseController : ControllerBase
    {
        private IEnumerable<string> GetModelStateError()
        {
            return ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
        } 

        protected JsonResult GetBasicSuccessJson()
        {
            return Json(new {IsSuccess = true});

        }

        protected JsonResult GetSuccessJson(BasicResponse response, object value)
        {
            return Json(new
            {
                IsSuccess = true,
                MessageInfoTextArray = response.GetMessageInfoTextArray(),
                Value = value,
            });
        }

        protected JsonResult GetErrorJson(string[] messages)
        {
            return Json(new
            {
                IsSuccess = false,
                MessageInfoTextArray = messages
            });
        }

        protected IActionResult GetApiError(string[] errorMessage, int? httpStatusCode = null)
        {
            var actualStatusCode = httpStatusCode.HasValue ? httpStatusCode.Value : 400;
            var responseObj = new ApiErrorModel
            {
                ErrorMessages = errorMessage,
            };

            return this.StatusCode(actualStatusCode, responseObj);
        }

        protected void PopulateCreatedFields<T>(AuditableDto<T> dto)
        {
            var currentUtcTime = DateTime.UtcNow;

            dto.CreatedBy = this.User != null &&  this.User.Identity != null && this.User.Identity.IsAuthenticated && !string.IsNullOrEmpty(this.User.Identity.Name) ? this.User.Identity.Name : "System";
            dto.CreatedAt = currentUtcTime;
            dto.UpdatedBy = this.User != null && this.User.Identity != null && this.User.Identity.IsAuthenticated && !string.IsNullOrEmpty(this.User.Identity.Name) ? this.User.Identity.Name : "System";
            dto.UpdatedAt = currentUtcTime;
        }

        protected void PopulatedUpdatedFields<T>(AuditableDto<T> dto)
        {
            var currentUtcTime = DateTime.UtcNow;

            dto.UpdatedBy = this.User != null && this.User.Identity != null && this.User.Identity.IsAuthenticated && !string.IsNullOrEmpty(this.User.Identity.Name) ? this.User.Identity.Name : "System";
            dto.UpdatedAt = currentUtcTime;
        }

        protected string GetUserTokenByRequestHeader()
        {
            var splitAuthorization = this.Request.Headers["Authorization"].ToString().Split(" ");
            return splitAuthorization.Length > 1 ? splitAuthorization[1] : string.Empty;
        }

        protected bool IsValidTimeZone(string timeZoneId)
        {
            try
            {
                TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                return true;
            }
            catch (TimeZoneNotFoundException)
            {
                return false;
            }
        }

        [NonAction]
        protected virtual JsonResult Json(object data)
        {
            return new JsonResult(data);
        }

        [NonAction]
        protected virtual JsonResult Json(object data, JsonSerializerSettings serializerSettings)
        {
            if (serializerSettings == null)
            {
                throw new ArgumentNullException(nameof(serializerSettings));
            }

            return new JsonResult(data, serializerSettings);
        }
    }
}
