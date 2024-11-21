namespace WebApplication1.Models
{
    public class StudentRepositry: IStudentRepositry
    {
        public StudentRepositry()
        {
            string filepath = @"D:\Sample.txt";
            string msg = "Student Repositry created at : @{ DateTime.Now.ToString()}";
            using (StreamWriter sw = new StreamWriter(filepath,true))
            {
                sw.WriteLine(msg);
            }

                
        }
        public List<Student> DataSource()
        {
            return new List<Student>()

            {
                new Student() { Studentid = 123, StudentName = "Janhavi", StudentAge = 23,StudentEmail = "Pawarjanhavi70@gmail.com" },
                new Student() { Studentid = 124, StudentName = "Janvi", StudentAge = 23,StudentEmail = "Pawar70@gmail.com" },
                new Student() { Studentid = 125, StudentName = "tanvi", StudentAge = 23,StudentEmail = "Pi70@gmail.com" },

            
        };

            
             
         }

        public Student GetStudentById(int StudentId)
        {
            return DataSource().FirstOrDefault(s=>s.Studentid == StudentId)??new Student();
        }

        public List<Student>GetAllStudents()
        {
            return DataSource();
        }


    }

}
