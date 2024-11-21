using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        //Constructor Injection
        private readonly IStudentRepositry? _studentRepositry;
        private readonly Dummyclass _dummyClass;


        public StudentController(IStudentRepositry studentRepositry, Dummyclass dummyClass)
        {
            _studentRepositry = studentRepositry;
            _dummyClass = dummyClass;
        }
        public JsonResult Index()
        {

            List<Student> students = _studentRepositry.GetAllStudents();
            return new JsonResult(students);


        }
        
     
        public JsonResult GetStudentDetails(int id)
        {
            
            Student studentdetails = _studentRepositry.GetStudentById(id);
            _dummyClass.DummyMethod(id);
            return Json(studentdetails);



        }

        //to get without curily braces
        /*public IActionResult GetStudentDetails(int id)
        {
            Student studentDetails = _studentRepositry.GetStudentById(id);
            _dummyClass.DummyMethod(id);

            // Format the student details as a plain text string
            string studentData = $"Student ID: {studentDetails.Studentid}, " +
                                 $"Student Name: {studentDetails.StudentName}, " +
                                 $"Student Age: {studentDetails.StudentAge}, " +
                                 $"Student Email: {studentDetails.StudentEmail}";

            // Return as plain text
            return Content(studentData, "text/plain");
        }*/


        public IActionResult About()
        {
            return View();
        }

    }
}
