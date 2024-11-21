namespace ModelBindingDemo.Models
{
    public class Branch
    {
       
        //scalar property
        public int Id { get; set; }

        public string BranchName { get; set; } = string.Empty;

        public string Discription { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        //Navigation property ie fk
        public ICollection<Student> ? Students { get; set; }
 

     
    }
}