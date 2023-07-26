using FoodPortal.Models;
using FoodPortal.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FoodPortal.Interfaces
{
    public interface IFoodTypeCountService
    {
        Task<List<FoodTypeCount>> Add_FoodTypeCount(List<FoodTypeCount> FoodTypeCount);

        Task<FoodTypeCount?> Delete_FoodTypeCount(IdDTO idDTO);
        Task<FoodTypeCount?> Update_FoodTypeCount(FoodTypeCount FoodTypeCount);
        Task<FoodTypeCount?> View_FoodTypeCount(IdDTO idDTO);
        Task<List<FoodTypeCount>?> View_All_FoodTypeCounts();
    }
}
