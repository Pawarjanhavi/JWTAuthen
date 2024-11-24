using Microsoft.AspNetCore.Http.HttpResults;
using WebApi_EFCore.Data;
using WebApi_EFCore.Models;

namespace WebApi_EFCore.Repository
{
    public class EmployeeRepository : IEmployeeServices
    {
        private ApplicationDBContext _dbContext;
        public EmployeeRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Employee> GetEmployeeList()
        {
            List<Employee> employees;
            try
            {
                employees = _dbContext.Set<Employee>().ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return employees;
        }
        public Employee GetEmployeeById(int id)
        {
            Employee emp;
            try
            {
                emp = _dbContext.Find<Employee>(id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return emp;
        }
        public ResponseModel SaveEmployee(Employee employee)
        {
            ResponseModel responseModel = new ResponseModel();
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return responseModel;
        }

        public ResponseModel UpdateEmployee(Employee employee)
        {
            ResponseModel responseModel = new ResponseModel();

            var result = _dbContext.Update<Employee>(employee);

            if (result != null)
            {
                var msg = responseModel.IsSuccess;
                msg = true;
                return responseModel ;
            }
            return responseModel;
        }
        public Employee DeleteEmployee(int id)
        {
            Employee emp;
            try
            {
                emp = _dbContext.Find<Employee>(id);
            }
            catch (Exception ex)
            {
                throw;
            }
            return emp;
        }

       
    }
}
