#nullable disable
using TA.Framework.Dto;

namespace TA.UserAccount.Dto
{
    public class UserRefreshTokenDto : AuditableDto<string>
    {
        public string UserUuid { get; set; }

        public string RefreshToken { get; set; }
    }
}
