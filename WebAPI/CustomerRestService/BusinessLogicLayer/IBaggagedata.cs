﻿
using DatabaseData.ModelLayer;
using RESTfulService.DTOs;
namespace RESTfulService.BusinessLogicLayer
{
    public interface IBaggagedata
    {
       BaggageDto? Get(int id);
        List<BaggageDto>? Get();
        int Add(BaggageDto baggageToAdd);
        bool Put(BaggageDto baggageToUpdate);
        bool Delete(int id);
    }
}
