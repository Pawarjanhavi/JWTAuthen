using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class EmptyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
