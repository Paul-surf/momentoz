using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.ModelLayer
{
    public class Bagage
    {
        public HandBagage HandBagage { get; set; }

        public CheckedBagage CheckedBagage { get; set; }

        public int TotalWeight { get; set; }

        public int Price { get; set; }


    }
}
