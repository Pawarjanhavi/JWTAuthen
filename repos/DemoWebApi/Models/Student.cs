using System.ComponentModel.DataAnnotations;

namespace DemoWebApi.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
