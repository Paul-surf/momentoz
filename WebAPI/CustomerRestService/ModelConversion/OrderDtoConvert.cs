        using RESTfulService.DTOs;
        using DatabaseData.ModelLayer;

        namespace RESTfulService.ModelConversion
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
                
                OrderID = inOrder.OrderID,
                TotalPrice = inOrder.TotalPrice,
                PurchaseDate = inOrder.PurchaseDate,
                CustomerID = inOrder.CustomerID
            };
        }
        public static Order ToOrder(OrderDto inDto)
        {
            Order? aOrder = null;
            if(inDto != null)
            {
                aOrder = new Order(inDto.OrderID, inDto.TotalPrice,  inDto.PurchaseDate, inDto.CustomerID, inDto.FlightID);
            }
            return aOrder;
        }
    }
}
//double totalPrice, DateTime purchaseDate, int? customerID, int? flightID