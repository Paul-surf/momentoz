namespace DatabaseData.ModelLayer
{
    public class Ticket
    {
   

/*        public Ticket(int tempId, string tempTicketType, int tempTicketNumber, int? tempBagageID, int? tempFlightID)
        {
            this.tempId = tempId;
            this.tempTicketType = tempTicketType;
            this.tempTicketNumber = tempTicketNumber;
            this.tempBagageID = tempBagageID;
            this.tempFlightID = tempFlightID;
        }*/
        public Ticket(string tempTicketType, int tempTicketNumber, int? tempBagageID, int? tempFlightID)
        {
            this.tempTicketType = tempTicketType;
            this.tempTicketNumber = tempTicketNumber;
            this.tempBagageID = tempBagageID;
            this.tempFlightID = tempFlightID;
        }
        public Ticket(int ID, string Type, int TicketNumber, int? tempBagageID, int? tempFlightID)
        {
            this.Id = ID;
            this.Type = Type;
            this.TicketNumber = TicketNumber;
            this.BagageID = BagageID;
            this.FlightID = FlightID;
        }
        public int Id { get; set; }
        public string Type { get; set; }
        public int TicketNumber { get; set; }

        public int BagageID { get; set; }

        public int FlightID { get; set; }








    }
}
