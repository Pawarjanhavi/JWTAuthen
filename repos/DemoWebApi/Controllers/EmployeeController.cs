using DemoWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> _employees= new List<Employee>()
        {
            new Employee(){EmployeeId = 1,Name = "Zahabiya",Gender = "Female",Department = "CSE",Age = 21,City = "Pune"},
            new Employee(){EmployeeId = 2,Name = "Tanya",Gender = "Female",Department = "IT",Age = 23,City = "Mumbai"},
            new Employee(){EmployeeId = 3,Name = "Rahul",Gender = "Male",Department = "EEE",Age = 25,City = "Chennai"},
            new Employee(){EmployeeId = 4,Name = "Pooja",Gender = "Female",Department = "CSE",Age = 21,City = "Pune"},
            new Employee(){EmployeeId = 5,Name = "Soniya",Gender = "Female",Department = "IT",Age = 23,City = "Bangalore"},
            new Employee(){EmployeeId = 6,Name = "Shubham",Gender = "Male",Department = "ME",Age = 25,City = "Chennai"},
            new Employee(){EmployeeId = 7,Name = "John",Gender = "Male",Department = "IT",Age = 21,City = "Pune"},
            new Employee(){EmployeeId = 8,Name = "Kevin",Gender = "Male",Department = "EEE",Age = 23,City = "Mumbai"},
            new Employee(){EmployeeId = 9,Name = "Somya",Gender = "Female",Department = "CSE",Age = 25,City = "Hyderabad"}
        };

        [HttpGet]
        public IActionResult GetEmployee(string department)
        {
            var employee = _employees.Where(e => e.Department.Equals(department,StringComparison.OrdinalIgnoreCase)).ToList();
            if (employee.Count() > 0)
            {
                return Ok(employee);
            }
            return NotFound($"No Employee Found for Department {department}");
        }

        [Route("Emp/Filter")]
        [HttpGet]
        public IActionResult GetEmps([FromQuery] Empsearch empsearch)
        {
            var empFilters = new List<Employee>();
            if (empsearch != null)
            {
                empFilters = _employees.Where(e => e.Department.Equals(empsearch.Department, StringComparison.OrdinalIgnoreCase)
                || e.Gender.Equals(empsearch.Gender, StringComparison.OrdinalIgnoreCase)).ToList();

                if (empFilters.Count() > 0)
                {
                    return Ok(empFilters);
                }
                return NotFound($"No Employee Found for Department {empsearch.Department} or Gender {empsearch.Gender}");
            }
            return BadRequest("Invalid filter");
        }

        [Route("Name")]
        [HttpGet]
        public string GetName()
        {
            return "Return Name";
        }

        [Route("Details")]
        [HttpGet]
        public Employee GetDetails()
        {
            return new Employee()
            {
                EmployeeId = 1,
                Name = "Zahabiya",
                Gender = "Female",
                Department = "CSE",
                Age = 20,
                City = "Pune"
            };
        }

        [Route("getAll")]
        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            return new List<Employee>(){
                new Employee(){EmployeeId = 1,Name = "Zahabiya",Gender = "Female",Department = "CSE",Age = 21,City = "Pune"},
                new Employee(){EmployeeId = 2,Name = "Tanya",Gender = "Female",Department = "IT",Age = 23,City = "Mumbai"},
                new Employee(){EmployeeId = 3,Name = "Rahul",Gender = "Male",Department = "EEE",Age = 25,City = "Chennai"}
            };
        }

        [Route("getAllEmployee")]
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            try
            {
                var allEmployees = new List<Employee>(){
                new Employee(){EmployeeId = 1,Name = "Zahabiya",Gender = "Female",Department = "CSE",Age = 21,City = "Pune"},
                new Employee(){EmployeeId = 2,Name = "Tanya",Gender = "Female",Department = "IT",Age = 23,City = "Mumbai"},
                new Employee(){EmployeeId = 3,Name = "Rahul",Gender = "Male",Department = "EEE",Age = 25,City = "Chennai"}
                };

                if (allEmployees.Any())
                {
                    //throw new Exception();
                    return Ok(allEmployees);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Server Error: "+e.Message);
            }
        }
    }
}
