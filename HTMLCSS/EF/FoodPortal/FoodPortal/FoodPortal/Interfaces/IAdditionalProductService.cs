using FoodPortal.Models;
using FoodPortal.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FoodPortal.Interfaces
{
    public interface IAdditionalProductService
    {
        Task<AdditionalProduct> Add_AdditionalProduct(AdditionalProduct AdditionalProduct);
        Task<AdditionalProduct?> Delete_AdditionalProduct(IdDTO idDTO);
        Task<AdditionalProduct?> Update_AdditionalProduct(AdditionalProduct AdditionalProduct);
        Task<AdditionalProduct?> View_AdditionalProduct(IdDTO idDTO);
        Task<List<AdditionalProduct>?> View_All_AdditionalProducts();

        Task<List<AdditionalProduct>?> View_by_category_AdditionalProducts(int cat);
        Task<List<AdditionalProduct>?> View_by_foodtype_AdditionalProducts(bool isveg, int cat);
    }
}
