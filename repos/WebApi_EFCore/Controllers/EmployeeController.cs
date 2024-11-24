using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_EFCore.Models;
using WebApi_EFCore.Repository;

namespace WebApi_EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeServices _employeeServices;
        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var empList = _employeeServices.GetEmployeeList();
            if (empList == null) return NotFound();
            return Ok(empList);
        }

        [Route("getEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var emp = _employeeServices.GetEmployeeById(id);
            if (emp == null) return NotFound();
            return Ok(emp);
        }

        [Route("createEmployee")]
        [HttpPost]
        public IActionResult createEmployee(Employee employee)
        {
            var create = _employeeServices.SaveEmployee(employee);
            return Ok(employee);
        }

        //[Route("updateEmployee")]
        //[HttpPost]
    }
}
