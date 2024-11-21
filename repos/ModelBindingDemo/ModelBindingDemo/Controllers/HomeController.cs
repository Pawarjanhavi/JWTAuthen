using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using ModelBindingDemo.Models;
using System.Diagnostics;

namespace ModelBindingDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitForm(User user)
        {
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    ViewBag.Message = $"User created as UserName:{user.UserName} for Email:{user.UserEmail}";
                    return View("Index");
                }
            }
            return View("Index", user);

            /*var keys=form.Keys;
            if(form.ContainsKey("UserName") && form.ContainsKey("UserEmail"))
            {
                if(form.TryGetValue("UserName",out StringValues userName)&& 
                    form.TryGetValue("UserEmail", out StringValues userEmail))
                {
                    ViewBag.Message = $"User created as UserName:{userName} for Email:{userEmail}";

                }
                else
                {
                    ViewBag.Message = "UserName or UserEmail not Found";
                }
            }
            else
            {
                ViewBag.Message = "Form does not contain Keys";
            }*/

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}