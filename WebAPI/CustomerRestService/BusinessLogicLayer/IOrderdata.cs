using DatabaseData.ModelLayer;
using CustomerRestService.DTOs;
namespace CustomerRestService.BusinessLogicLayer
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
