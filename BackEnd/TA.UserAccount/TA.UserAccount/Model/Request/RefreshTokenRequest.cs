using System.ComponentModel.DataAnnotations;

namespace TA.UserAccount.Model.Request
{
#nullable disable
    public class RefreshTokenRequest
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
