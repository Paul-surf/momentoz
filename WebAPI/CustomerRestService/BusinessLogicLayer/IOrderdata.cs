using RESTfulService.DTOs;
namespace RESTfulService.BusinessLogicLayer
{
    public interface IOrderdata
    {   
        OrderDto? Get(int id);
        List<OrderDto>? Get();
        int CreateNewOrder(OrderDto orderToAdd);
        bool Put(OrderDto orderToUpdate);
        bool Delete(int id);

    }
}
