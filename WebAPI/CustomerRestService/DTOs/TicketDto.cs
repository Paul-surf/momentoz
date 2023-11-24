namespace CustomerRestService.DTOs
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int TicketNumber { get; set; }
        public int? BaggageID { get; set; }
        public int? FlightID { get; set; }
    }
}
