#nullable disable
using TA.Framework.Dto;

namespace TA.UserAccount.Dto
{
    public class UserInRoleDto : AuditableDto<int>
    {
        public string UserUuid { get; set; }

        public string RoleUuid { get; set; }
    }
}
