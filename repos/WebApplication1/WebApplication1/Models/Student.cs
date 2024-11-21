using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Student
    {

        public int Studentid { get; set; }
        [Required]

        public string StudentName { get; set; }
        [Required]

        public int StudentAge { get; set; }
        [Required]

        public string ? StudentEmail { get; set; }

    }
}
