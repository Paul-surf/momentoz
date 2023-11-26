
using DatabaseData.ModelLayer;
using System;

namespace RESTfulService.DTOs
{
    public class BaggageDto
    {

        public BaggageDto() { }

        public BaggageDto(double inTotalWeight, double inPrice)
        {
       
            TotalWeight = inTotalWeight;
            Price = inPrice;
            //    HandBaggageId = inHandBaggageID;
            //  CheckedBaggageId = inCheckedBaggageId;
        }
        public int Id { get; set; }
        public double TotalWeight { get; set; }
        public double Price { get; set; }
        
        //    public int HandBaggageId { get; set; }
        //  public int CheckedBaggageId { get; set; }
    }
}