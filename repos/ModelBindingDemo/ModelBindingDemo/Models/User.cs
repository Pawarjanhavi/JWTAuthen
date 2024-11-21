using System.ComponentModel.DataAnnotations;



namespace ModelBindingDemo.Models
{
    public class User
    {
        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; } // Primary Key 

        [Required(ErrorMessage = "Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        public string UserEmail { get; set; }
    }
}