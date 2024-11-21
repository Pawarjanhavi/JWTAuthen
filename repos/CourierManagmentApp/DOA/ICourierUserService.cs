using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOA
{
    public interface ICourierUserService
    {
        // Customer-related functions
        string PlaceOrder(Courier courierObj);

        string GetOrderStatus(string trackingNumber);

        bool CancelOrder(string trackingNumber);

        List<Courier> GetAssignedOrders(string courierStaffId);
    }

}
