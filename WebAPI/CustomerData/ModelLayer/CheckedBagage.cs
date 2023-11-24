namespace DatabaseData.ModelLayer
{
    public class CheckedBagage
    {
        public int Weight { get; set; }

        public CheckedBagage(int weight = 20)
        {
            Weight = weight;
        }
    }
}
