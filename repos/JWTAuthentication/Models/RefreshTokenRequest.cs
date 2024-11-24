using System.ComponentModel.DataAnnotations;

namespace JWTAuthentication.Models
{
    public class RefreshTokenRequest
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
