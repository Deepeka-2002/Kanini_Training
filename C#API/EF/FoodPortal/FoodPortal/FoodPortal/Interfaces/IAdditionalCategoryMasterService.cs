using FoodPortal.Models;
using FoodPortal.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FoodPortal.Interfaces
{
    public interface IAdditionalCategoryMasterService
    {

        Task<AdditionalCategoryMaster> Add_AdditionalCategoryMaster(AdditionalCategoryMaster additionalCategoryMaster);

        Task<AdditionalCategoryMaster?> Delete_AdditionalCategoryMaster(IdDTO idDTO);

        Task<AdditionalCategoryMaster?> Update_AdditionalCategoryMaster(AdditionalCategoryMaster additionalCategoryMaster);
        Task<AdditionalCategoryMaster?> View_AdditionalCategoryMaster(IdDTO idDTO);

        Task<List<AdditionalCategoryMaster>?> View_All_AdditionalCategoryMasters();

    }
}
