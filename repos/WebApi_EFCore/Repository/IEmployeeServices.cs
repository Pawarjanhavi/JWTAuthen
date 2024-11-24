using WebApi_EFCore.Models;

namespace WebApi_EFCore.Repository
{
    public interface IEmployeeServices
    //public interface IEmployeeServices<TEntity>

    {
        public List<Employee> GetEmployeeList();
        public Employee GetEmployeeById(int id);
        public ResponseModel SaveEmployee(Employee employee);
        public ResponseModel UpdateEmployee(Employee employee);
        public Employee DeleteEmployee(int id);

    }
}
