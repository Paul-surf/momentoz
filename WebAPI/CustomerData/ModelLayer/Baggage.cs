namespace DatabaseData.ModelLayer
{
    // Baggage-klassen repræsenterer information om bagage.
    public class Baggage
    {
        // Standardkonstruktør, der initialiserer en tom Baggage.
        public Baggage() { }

        // Konstruktør, der initialiserer Baggage med totalvægt og pris.
        public Baggage(double totalWeight, double price)
        {
            this.TotalWeight = totalWeight;
            this.Price = price;
        }

        // Konstruktør, der initialiserer Baggage med ID, totalvægt og pris.
        // Den bruger constructor chaining til at kalde den forrige konstruktør.
        public Baggage(int id, double totalWeight, double price) : this(totalWeight, price)
        {
            Id = id;
        }

        // Egenskab for Baggage-ID.
        public int Id { get; set; }

        // Egenskab for totalvægten af bagagen.
        public double TotalWeight { get; set; }

        // Egenskab for prisen på bagagen.
        public double Price { get; set; }
    }
}
