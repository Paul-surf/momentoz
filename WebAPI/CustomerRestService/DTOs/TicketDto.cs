namespace CustomerRestService.DTOs
{
    public class TicketDto
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public int TicketNumber { get; set; }
        public int? BagageID { get; set; }
        public int? FlightID { get; set; }
    }
}
