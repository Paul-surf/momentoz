using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.ModelLayer
{
    public class CheckedBaggage
    {
        public int BaggageWeight { get; set; }

        public int CheckedBaggageId { get; set; }
        public CheckedBaggage(int weight = 20)
        {
            BaggageWeight = weight;
        }
    }
}
