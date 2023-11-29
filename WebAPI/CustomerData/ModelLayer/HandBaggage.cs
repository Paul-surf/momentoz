namespace DatabaseData.ModelLayer
{
    public class HandBaggage
    {
        public HandBaggage(int weight = 5)
        {
            BaggageWeight = weight;
        }
        public int HandBaggageID { get; set; }
        public int BaggageWeight { get; set; }
    }
}
