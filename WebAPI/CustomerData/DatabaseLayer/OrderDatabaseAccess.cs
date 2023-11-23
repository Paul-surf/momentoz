using DatabaseData.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.DatabaseLayer
{
    public class OrderDatabaseAccess : IOrderAccess
    {
        public int CreateOrder(Order ticketToAdd)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrderAll()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrder(Order ticketToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
