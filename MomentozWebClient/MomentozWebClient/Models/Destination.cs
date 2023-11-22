namespace MomentozWebClient.Models
{
    public class Destination
    {
        string city{ get; set; }
        string depature { get; set; }

        string travelDestination { get; set; }

        int price { get; set; }

        DateTime depaturetime { get; set; }

      

        public Destination(string city, string depature, string travelDestination, int price, DateTime depaturetime)
        {
            this.city = city;
            this.depature = depature;
            this.travelDestination = travelDestination;
            this.price = price;
            this.depaturetime = depaturetime;
        }
    }
}
