using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
