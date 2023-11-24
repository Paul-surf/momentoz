using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.ModelLayer
{
    public class HandBagage
    {
        public HandBagage(int weight = 5)
        {
            Weight = weight;
        }

        public int Weight { get; set; }
    }
}
