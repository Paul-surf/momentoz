using RESTfulService.DTOs;
namespace RESTfulService.BusinessLogicLayer
{
    public interface IOrderdata
    {   
        OrderDto? Get(int id);
        List<OrderDto>? Get();
        OrderDto CreateOrder(OrderDto orderToAdd);
        OrderDto Put(OrderDto orderToUpdate);
        bool Delete(int id);

    }
}
