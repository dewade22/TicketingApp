#nullable disable
using TA.Framework.Dto;

namespace TA.UserAccount.Dto
{
    public class RolesDto : AuditableDto<int>
    {
        public string RoleName { get; set; }
    }
}
