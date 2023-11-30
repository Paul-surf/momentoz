namespace MomentozWebClient.Models
{
    public class Ticket
    {
        public Ticket(string tempTicketType, int tempTicketNumber, int? tempBaggageID, int? tempFlightID)
        {
            this.Type = tempTicketType;
            this.TicketNumber = tempTicketNumber;
            this.BaggageID = tempBaggageID;
            this.FlightID = tempFlightID;
        }
        public Ticket(int ID, string Type, int TicketNumber, int? tempBaggageID, int? tempFlightID)
        {
            this.Id = ID;
            this.Type = Type;
            this.TicketNumber = TicketNumber;
            this.BaggageID = tempBaggageID;
            this.FlightID = tempFlightID;
        }
        public Ticket(int ID, string Type, int TicketNumber, int? tempFlightID)
        {
            this.Id = ID;
            this.Type = Type;
            this.TicketNumber = TicketNumber;
            this.FlightID = tempFlightID;
        }
        public int Id { get; set; }
        public string Type { get; set; }
        public int TicketNumber { get; set; }
        public int? BaggageID { get; set; }
        public int? FlightID { get; set; }
        public Ticket() { }
        public Ticket(int flightId) 
        {
            this.FlightID = flightId;
        }
    }
}
