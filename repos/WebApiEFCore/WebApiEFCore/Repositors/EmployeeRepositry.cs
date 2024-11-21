using WebApiEFCore.Data;
using WebApiEFCore.Models;

namespace WebApiEFCore.Repositors
{
    public class EmployeeRepositry:IEmployeeServices

    {
        private EmpDBContext _context;

        public EmployeeRepositry(EmpDBContext context)
        {
            _context = context;
        }

        public List<Employee> GetEmployeesList()
        {
            List<Employee> empList;
            try
            {
                empList = _context.Set<Employee>().ToList();

            }
            catch (Exception ex)
            {
                throw;
            }
            return empList;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee emp;
            try
            {
                emp = _context.Find<Employee>(id);
            }
            catch(Exception ex)
            {
                
                throw;
            }
            return emp;
        }

        public Employee SaveEmployee(Employee employee)
        {
            throw new NotImplementedException("SaveEmployee is not implemented.");
        }

        public Employee UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException("UpdateEmployee is not implemented.");
        }

        public Employee DeleteEmployee(int id)
        {
            throw new NotImplementedException("DeleteEmployee is not implemented.");
        }


    }
}
