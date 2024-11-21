namespace ModelBindingDemo.Models
{
    public class Student
    {
        //scalar properties

        public int StudentId { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ? Phone { get; set; } = string.Empty;

        //Navigation Properties
        public virtual Branch? Branch { get; set; }



    }
}
