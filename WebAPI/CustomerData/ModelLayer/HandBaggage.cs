using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
