namespace DatabaseData.ModelLayer
{
    public class Baggage { 

        public Baggage() { }

        public Baggage(double totalWeight, double price)
        {
            this.TotalWeight = totalWeight;
            this.Price = price;
        }
        public Baggage(int id, double totalWeight, double price) : this(totalWeight, price)
    {
        Id = id;
    }
        public int Id { get; set; }

        public double TotalWeight { get; set; }

        public double Price { get; set; }


    }
}
