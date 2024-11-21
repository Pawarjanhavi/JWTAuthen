namespace WebApplication1.Models
{
    public class Dummyclass
    {

        private readonly IStudentRepositry _repositry;

        public Dummyclass(IStudentRepositry studentRepositry)
        {
            _repositry = studentRepositry;
        }

        public void DummyMethod(int Id)
        {
            Student studentdetails = _repositry.GetStudentById(Id);
        }
    }
}
