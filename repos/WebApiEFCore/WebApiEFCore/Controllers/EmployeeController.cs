using Microsoft.AspNetCore.Mvc;
using WebApiEFCore.Repositors;

namespace WebApiEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        IEmployeeServices _employeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }
        [Route("GetAll")]
        [HttpGet]

        public IActionResult GetAll()
        {
            try
            {
                var emp = _employeeServices.GetEmployeesList();
                if (emp == null) return NotFound();
                return Ok(emp);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
