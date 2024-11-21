using Car2Go.Models;
using System.ComponentModel.DataAnnotations;

namespace ModelBindingDemo.Models
    
{
    public class User
        {
            [Key]
            public int UserId { get; set; }

            [Required(ErrorMessage = "First Name is required.")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Last Name is required.")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid Email Format!.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Phone Number is required.")]
            [Phone(ErrorMessage = "Invalid phone number format.")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            public string Password { get; set; }

           [Required(ErrorMessage = "Role is required.")]
           public string Role { get; set; } 


        //navigation properties

        public ICollection<Review> Reviews { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }

    /*public enum Role
    {
        Customer,
        Agent,
        Admin
    }*/

    



}



