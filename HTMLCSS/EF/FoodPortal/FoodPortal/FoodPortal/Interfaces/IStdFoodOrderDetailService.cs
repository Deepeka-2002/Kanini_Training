using FoodPortal.Models;
using FoodPortal.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FoodPortal.Interfaces
{
    public interface IStdFoodOrderDetailService
    {
        Task<List<StdFoodOrderDetail>> Add_StdFoodOrderDetail(List<StdFoodOrderDetail> StdFoodOrderDetails);
        Task<StdFoodOrderDetail?> Delete_StdFoodOrderDetail(IdDTO idDTO);
        Task<StdFoodOrderDetail?> Update_StdFoodOrderDetail(StdFoodOrderDetail StdFoodOrderDetail);
        Task<StdFoodOrderDetail?> View_StdFoodOrderDetail(IdDTO idDTO);
        Task<List<StdFoodOrderDetail>?> View_All_StdFoodOrderDetails();
    }
}
