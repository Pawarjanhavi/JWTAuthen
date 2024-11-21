namespace WebApplication1.Models
{
    public interface IStudentRepositry
    {
        Student GetStudentById(int Studentid);

        List<Student>GetAllStudents();

    }
}
