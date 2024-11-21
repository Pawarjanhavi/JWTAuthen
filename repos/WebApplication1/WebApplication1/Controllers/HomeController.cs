using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ViewResult Details()
        {
            //VIEWDATA
            /*ViewData["Title"] = "Students Detail Page";
            ViewData["Header"] = "Student Details";*/

            //VIEWBAG
            ViewBag.Title = "Students Detail Page";
            ViewBag.Header = "Student Details";


            Student student = new Student
            {
                Studentid = 126, 
                StudentName = "Riya",
                StudentAge = 25,
                StudentEmail = "Riya@gmail.com"

            };

            //ViewData["Student"] = student;

            ViewBag.Student = student;

            return View();
            

        }
        public IActionResult Index()
        {
            TempData["Name"] = "Janhavi";
            TempData["Designation"] = "Software engineer";
            ViewData["Address"] = "Kopargaon";
            
            return View();
        }

        public IActionResult Privacy()
        {
            TempData["Name"] = "Janhavi";
            TempData["Designation"] = "Software engineer";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
