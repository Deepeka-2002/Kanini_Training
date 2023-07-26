using FoodPortal.Models;
using FoodPortal.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FoodPortal.Interfaces
{
    public interface IAdditionalProductsDetailService
    {
        Task<List<AdditionalProductsDetail>> Add_AdditionalProductsDetail(List<AdditionalProductsDetail> AdditionalProductsDetail);
        Task<AdditionalProductsDetail?> Delete_AdditionalProductsDetail(IdDTO idDTO);
        Task<AdditionalProductsDetail?> Update_AdditionalProductsDetail(AdditionalProductsDetail AdditionalProductsDetail);
        Task<AdditionalProductsDetail?> View_AdditionalProductsDetail(IdDTO idDTO);
        Task<List<AdditionalProductsDetail>?> View_All_AdditionalProductsDetails();
    }
}
