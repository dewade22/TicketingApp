#nullable disable
using TA.Framework.Dto;

namespace TA.UserAccount.Dto
{
    public class UserMembershipDto : AuditableDto<string>
    {
        public string UserUuid { get; set; }

        public string Password { get; set; }
    }
}
