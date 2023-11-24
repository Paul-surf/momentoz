using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseData.ModelLayer
{
    public class Baggage
    {
        public string HandBaggageId { get; set; }

        public string CheckedBaggageId { get; set; }

        public int TotalWeight { get; set; }

        public int Price { get; set; }


    }
}
