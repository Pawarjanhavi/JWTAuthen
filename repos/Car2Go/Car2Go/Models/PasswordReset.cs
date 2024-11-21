using ModelBindingDemo.Models;
using System.ComponentModel.DataAnnotations;

namespace Car2Go.Models
{
    public class PasswordReset
    {
        [Required(ErrorMessage = "Reset ID is required")]
        public int ResetId { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Reset Token is required.")]
        public string ResetToken { get; set; }
        [Required(ErrorMessage = "RequestedAt timestamp is required.")]
        public DateTime RequestedAt { get; set; }

        [Required(ErrorMessage = "ExpiresAt timestamp is required.")]
        public DateTime ExpiresAt { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        // Navigation Property
        [Required(ErrorMessage = "Associated User is required.")]
        public User User { get; set; }
    }
}
