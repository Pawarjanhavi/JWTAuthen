using WebApiEFCore.Models;

namespace WebApiEFCore.Repositors
{
    public interface IEmployeeServices
    {
        List<Employee> GetEmployeesList();

        Employee GetEmployeeById(int id);
        public Employee SaveEmployee(Employee employee);
        public Employee UpdateEmployee(Employee employee);

        public Employee DeleteEmployee(int id);



    }
}
