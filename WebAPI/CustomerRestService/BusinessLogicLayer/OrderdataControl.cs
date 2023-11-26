using DatabaseData.ModelLayer;
using DatabaseData.DatabaseLayer;
using RESTfulService.DTOs;
using RESTfulService.BusinessLogicLayer;
using System;

namespace RESTfulService.BusinessLogicLayer
{
    public class OrderdataControl : IOrderdata
    {
        private readonly IOrderAccess _orderAccess;

        public OrderdataControl(IOrderAccess inOrderAccess)
        {
            _orderAccess = inOrderAccess;
        }


        public OrderDto? Get(int idToMatch)
        {
            OrderDto? foundOrderDto;
            try
            {
                Order? foundOrder = _orderAccess.GetOrderById(idToMatch);
                foundOrderDto = ModelConversion.OrderDtoConvert.FromOrder(foundOrder);
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
                List<Order>? foundOrders = _orderAccess.GetOrderAll();
                foundDtos = ModelConversion.OrderDtoConvert.FromOrderCollection(foundOrders);
            }
            catch
            {
                foundDtos = null;
            }
            return foundDtos;
        }


        public int Add(OrderDto newOrder)
        {
            int insertedId = 0;
            try
            {
                Order? foundOrder = ModelConversion.OrderDtoConvert.ToOrder(newOrder);
                if (foundOrder != null)
                {
                    insertedId = _orderAccess.CreateOrder(foundOrder);
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
