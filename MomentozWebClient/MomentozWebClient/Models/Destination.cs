namespace MomentozWebClient.Models
{
    public class Destination
    {
       public string city{ get; set; }
       public string depature { get; set; }

       public string travelDestination { get; set; }

       public int price { get; set; }

       public DateTime depaturetime { get; set; }

      

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
