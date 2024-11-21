using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoIntrWebAPI.models;

namespace DemoIntrWebAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class StudentController : ControllerBase
    {
        [Route("Student/List")]
        [HttpGet]
        public string GetList()
        {
            return "Hi from student controller";
        }

        //[Route("Student/id/{id}/City/{city}")]//Route Data
        [Route("Student/Search")]
        [HttpGet]

        public string GetStudentById(int id , string city)
        {
            return $"Hi from Get All Student: {id} comming from {city}";
        }

        [Route("Student/Get")]
        [HttpGet]

        public string SearchStudent([FromQuery] Student s)
        {
            return $"Data : { s.Studentid} { s.StudentName} { s.Address} { s.Email}";
        }
    }
}
