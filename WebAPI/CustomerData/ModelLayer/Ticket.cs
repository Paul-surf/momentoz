namespace DatabaseData.ModelLayer
{
    public class Ticket
    {
       public string TicketType { get; set; }
       public int TicketNumber { get; set; }

        public Bagage Bagage { get; set; }

        public Flight Flight { get; set; }








    }
}
