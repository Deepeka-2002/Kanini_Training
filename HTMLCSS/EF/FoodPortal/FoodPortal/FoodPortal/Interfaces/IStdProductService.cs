using FoodPortal.Models;
using FoodPortal.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FoodPortal.Interfaces
{
    public interface IStdProductService
    {
        Task<StdProduct> Add_StdProduct(StdProduct StdProduct);
        Task<StdProduct?> Delete_StdProduct(IdDTO idDTO);
        Task<StdProduct?> Update_StdProduct(StdProduct StdProduct);
        Task<StdProduct?> View_StdProduct(IdDTO idDTO);
        Task<List<StdProduct>?> View_All_StdProducts();

        Task<List<StdProduct>> View_by_category_StdProducts(int cat);

        Task<List<StdProduct>> View_by_foodtype_StdProducts(bool isveg,int cat);


    }
}
