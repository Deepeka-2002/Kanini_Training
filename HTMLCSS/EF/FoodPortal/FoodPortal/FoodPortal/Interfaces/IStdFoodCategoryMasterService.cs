using FoodPortal.Models;
using FoodPortal.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FoodPortal.Interfaces
{
    public interface IStdFoodCategoryMasterService
    {
        Task<StdFoodCategoryMaster> Add_StdFoodCategoryMaster(StdFoodCategoryMaster StdFoodCategoryMaster);
        Task<StdFoodCategoryMaster?> Delete_StdFoodCategoryMaster(IdDTO idDTO);
        Task<StdFoodCategoryMaster?> Update_StdFoodCategoryMaster(StdFoodCategoryMaster StdFoodCategoryMaster);
        Task<StdFoodCategoryMaster?> View_StdFoodCategoryMaster(IdDTO idDTO);
        Task<List<StdFoodCategoryMaster>?> View_All_StdFoodCategoryMasters();
    }
}
