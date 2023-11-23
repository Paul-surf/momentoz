using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseData.ModelLayer;

namespace DatabaseData.DatabaseLayer
{
    public interface IOrderAccess
    {
        Order GetOrderById(int id);
        List<Order> GetOrderAll();
        int CreateOrder(Order ticketToAdd);
        bool UpdateOrder(Order ticketToUpdate);
        bool DeleteOrderById(int id);
    }
}
