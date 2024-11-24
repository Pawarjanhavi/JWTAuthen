using DemoWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApi.Controllers
{
    //[Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [Route("Student/List")]
        [HttpGet]
        public string GetStudentList()
        {
            return "Hi from Get Student List";
        }

        //[Route("Student/id/{id}/city/{city}")]  //Route data

        [Route("Student/Get")]
        [HttpGet]
        public string GetStudentById(int Id,string City)
        {
            return $"Hi from Student:{Id} coming from {City}";
        }


        [Route("Student/Search")]
        [HttpGet]
        public string SearchStudent([FromQuery] Student s)
        {
            return $"Data: {s.StudentId},{s.StudentName},{s.Address},{s.Email}";
        }
    }
}
