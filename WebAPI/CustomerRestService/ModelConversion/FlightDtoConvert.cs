        using DatabaseData.ModelLayer;

        namespace RESTfulService.ModelConversion
        {
        public class FlightDtoConvert
        {
        public static List<DTOs.FlightDto>? FromFlightCollection(List<Flight> inFlights)
        {
            List<DTOs.FlightDto>? aFlightReadDtoList = null;
            if (inFlights != null)
            {
                aFlightReadDtoList = new List<DTOs.FlightDto>();
                DTOs.FlightDto? tempDto;
                foreach (Flight aFlight in inFlights)
                {
                    if (aFlight != null)
                    {
                        tempDto = FromFlight(aFlight);
                        aFlightReadDtoList.Add(tempDto);
                    }
                }
            }
            return aFlightReadDtoList;
        }
        public static DTOs.FlightDto? FromFlight(Flight inFlight)
        {
            DTOs.FlightDto? aFlightReadDto = null;
            if (inFlight != null)
            {
                aFlightReadDto = new DTOs.FlightDto(inFlight.FlightID, inFlight.Departure, inFlight.DestinationAddress, inFlight.DestinationCountry, inFlight.HomeTrip, inFlight.Price);
            }
            return aFlightReadDto;
        }
        public static Flight? ToFlight(DTOs.FlightDto inDto)
        {
            Flight? aFlight = null;
            if (inDto != null)
            {
                aFlight = new Flight(inDto.Departure, inDto.Price, inDto.DestinationAddress, inDto.DestinationCountry, inDto.HomeTrip);
            }
            return aFlight;
        }
    }
}
