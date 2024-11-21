using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOA
{
    public interface ICourierAdminService
    {
        void AddCourier(Courier courier);
        void RemoveCourier(string trackingNumber);
        List<Courier> GetAllCouriers();
        List<Employee> GetAllEmployees();
        void AddEmployee(Employee employee);

        // Add this method
        
    }

}
