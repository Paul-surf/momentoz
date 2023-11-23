using CustomerRestService.DTOs;
using DatabaseData.ModelLayer;
using System.Collections.Generic;
namespace CustomerRestService.ModelConversion
{
    public class OrderDtoConvert
    {
        public static List<OrderDto> FromOrderCollection(List<Order> inOrder)
        {
            var aOrderReadDtoList = new List<OrderDto>();
            foreach (Order aOrder in inOrder)
            {
                var tempDto = FromOrder(aOrder);
                aOrderReadDtoList.Add(tempDto);
            }
            return aOrderReadDtoList;
        }
        public static OrderDto FromOrder(Order inOrder)
        {
            return new OrderDto
            {
                ID = inOrder.ID,
                TotalPrice = inOrder.TotalPrice,
                DateForPurchase = inOrder.DateForPurchase,
                TicketID = inOrder.TicketID,
                CustomerID = inOrder.CustomerID
            };
        }
        public static Order ToOrder(OrderDto inDto)
        {
            return new Order(inDto.ID, inDto.TotalPrice, inDto.DateForPurchase, inDto.CustomerID, inDto.TicketID);
        }
    }
}
