using MomentozClientApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MomentozClientApp.BusinessLogicLayer
{
    public interface IOrderdata
    {
        OrderDto? Get(int id);
        List<OrderDto>? Get();
        int Add(OrderDto orderToAdd);
        bool Put(OrderDto orderToUpdate);
        bool Delete(int id);
    }
}
