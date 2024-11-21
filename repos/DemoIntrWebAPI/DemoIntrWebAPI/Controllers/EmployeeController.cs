using Microsoft.AspNetCore.Mvc;
using DemoIntrWebAPI.models;

namespace DemoIntrWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private static List<Employee> _employee = new List<Employee>
        {
             new Employee() {id = 12, Name = "Purva", gender = "female", Department = "IT", Age = "21", City = "Nasik"},
                 new Employee() {id = 12, Name = "Tejas", gender = "male", Department = "CS", Age = "22", City = "Nasik"},
                  new Employee() {id = 12, Name = "Tanu", gender = "female", Department = "IT", Age = "21", City = "Nasik"}


        };

        [Route("GetEmployee")]
        [HttpGet]
        public IActionResult GetEmployee(string Department)
        {
            var employee = _employee.Where(emp => emp.Department.Equals(Department, StringComparison.OrdinalIgnoreCase)).ToList();
            if(employee.Count > 0)
            {
                return Ok(employee);
            }
            return NotFound($"No Employee found for department{Department}");

        }

        [Route("Emp/Filter")]
        [HttpPost]

        public IActionResult GetEmp([FromQuery] EmpSearch empSearch)
        {
            var empFilters = new List<Employee>();
            if(empSearch != null)
            {
                empFilters = _employee.Where(
                    emp => emp.Department.Equals(empSearch.Department, StringComparison.OrdinalIgnoreCase)
                    ||
                    emp.gender.Equals(empSearch.Gender, StringComparison.OrdinalIgnoreCase)

                    ).ToList();
                if(empFilters.Count > 0)
                {
                    return Ok(empFilters);
                }
                return NotFound($"No Employee found fo r Department {empSearch?.Department} or Gender{empSearch?.Gender}");
            }
            return BadRequest("Invalid Filter");
        }


        [Route("Name")]
        [HttpGet]


        public string GetName()
        {
            return "Return Name ";
        }

        [Route("Details")]
        [HttpGet]
        public Employee GetDetails()
        {
            return new Employee()
            {
                id = 123,
                Name = "Janhavi",
                gender = "female",
                Department = "IT",
                Age = "21",
                City = "Kopargaon"
            };

            
        }

        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            return new List<Employee>()
            {
                new Employee() {id = 12, Name = "Purva", gender = "female", Department = "IT", Age = "21", City = "Nasik"},
                 new Employee() {id = 12, Name = "Tejas", gender = "male", Department = "CS", Age = "22", City = "Nasik"},
                  new Employee() {id = 12, Name = "Tanu", gender = "female", Department = "IT", Age = "21", City = "Nasik"}

            };
        }

        [Route("getallemployess")]
        [HttpGet]

        public IActionResult GetAllEmployee()
        {
            try
            {
                var AllEmployees = new List<Employee>
                {
                    new Employee() {id = 12, Name = "Purva", gender = "female", Department = "IT", Age = "21", City = "Nasik"},
                    new Employee() {id = 12, Name = "Tejas", gender = "male", Department = "CS", Age = "22", City = "Nasik"},
                    new Employee() {id = 12, Name = "Tanu", gender = "female", Department = "IT", Age = "21", City = "Nasik"}

                };

                if(AllEmployees.Any())
                {
                    return Ok(AllEmployees);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Server Error :" + ex.Message);
            }
        }
    }
}
