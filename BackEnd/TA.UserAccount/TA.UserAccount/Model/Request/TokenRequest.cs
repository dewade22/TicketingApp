#nullable disable
using TA.Framework.Dto;

namespace TA.UserAccount.Model.Request
{
    public class TokenRequest
    {
        public string UserUuid { get; set; }

        public string EmailAddress { get; set; }

        public string Role { get; set; }
    }
}
