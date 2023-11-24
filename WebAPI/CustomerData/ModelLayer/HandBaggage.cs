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
            BaggegeWeight = weight;
        }

        public int HandBaggageID { get; set; }
        public int BaggegeWeight { get; set; }


    }
}
