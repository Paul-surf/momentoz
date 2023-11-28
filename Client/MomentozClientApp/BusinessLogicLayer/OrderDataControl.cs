using MomentozClientApp.DTOs;
using MomentozClientApp.ModelLayer;
using MomentozClientApp.ServiceLayer;

namespace MomentozClientApp.BusinessLogicLayer
{
    public class OrderdataControl : IOrderdata
    {
        private readonly IOrderAccess _orderAccess;

        public OrderdataControl(IOrderAccess inOrderAccess)
        {
            _orderAccess = inOrderAccess;
        }


        public OrderDto? Get(int id)
        {
            OrderDto? foundOrderDto;
            try
            {
                var foundOrder = _orderAccess.GetOrderById(id).Result;
                return ModelConversion.OrderDtoConvert.FromOrder(foundOrder);
            }
            catch
            {
                foundOrderDto = null;
            }
            return foundOrderDto;
        }


        public List<OrderDto>? Get()
        {
            List<OrderDto>? foundDtos;
            try
            {
                List<Order>? foundOrders = _orderAccess.GetOrderAll().Result;
                foundDtos = ModelConversion.OrderDtoConvert.FromOrderCollection(foundOrders);
            }
            catch
            {
                foundDtos = null;
            }
            return foundDtos;
        }


        public int Add(OrderDto orderToAdd)
        {
            int insertedId = 0;
            try
            {
                Order? foundOrder = ModelConversion.OrderDtoConvert.ToOrder(orderToAdd);
                if (foundOrder != null)
                {
                    return _orderAccess.CreateOrder(foundOrder).Result;
                }
            }
            catch
            {
                insertedId = -1;
            }
            return insertedId;
        }

        public bool Put(OrderDto orderToUpdate)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
