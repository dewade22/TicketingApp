#nullable disable
using System.ComponentModel.DataAnnotations;

namespace TA.UserAccount.Model.Request
{
    public class AssignRoleRequest
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string RoleUuid { get; set; }
    }
}
