        using RESTfulService.DTOs;
        using DatabaseData.ModelLayer;

        namespace RESTfulService.ModelConversion
        {
        public class OrderDtoConvert
        {
        public static List<OrderDto> FromOrderCollection(List<Order> inOrders)
        {
            if (inOrders == null)
                return null;
            var aOrderReadDtoList = new List<OrderDto>();
            foreach (Order aOrder in inOrders)
            {
                var tempDto = FromOrder(aOrder);
                aOrderReadDtoList.Add(tempDto);
            }
            return aOrderReadDtoList;
        }
        //public static OrderDto FromOrder(Order inOrder)
        //{
        //    return new OrderDto
        //    {
        //        OrderID = inOrder.OrderID,
        //        TotalPrice = inOrder.TotalPrice,
        //        PurchaseDate = inOrder.PurchaseDate,
        //        CustomerID = inOrder.CustomerID
        //    };
        //}
        public static OrderDto FromOrder(Order inOrder)
        {
            if (inOrder == null)
                return null;

            return new OrderDto(inOrder.OrderID, inOrder.TotalPrice, inOrder.PurchaseDate, inOrder.CustomerID, inOrder.FlightID);
        }
        //(int inFlightID, string? inDeparture,  string? inDestinationAddress, string? inDestinationCountry, DateTime? homeTrip, double inPrice)
        public static Order ToOrder(OrderDto inDto)
        {
            //Order? aOrder = null;
            //if(inDto != null)
                if (inDto == null)
                    return null;
            //{
            //    aOrder = new Order(inDto.OrderID, inDto.TotalPrice,  inDto.PurchaseDate, inDto.CustomerID, inDto.FlightID);
            //}
            //return aOrder;
            return new Order(inDto.OrderID, inDto.TotalPrice, inDto.PurchaseDate, inDto.CustomerID, inDto.FlightID);
        }
    }
}
