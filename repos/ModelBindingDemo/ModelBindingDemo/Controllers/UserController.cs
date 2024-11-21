using Microsoft.AspNetCore.Mvc;

namespace ModelBindingDemo.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
