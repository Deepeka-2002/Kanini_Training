using FoodPortal.Models;
using FoodPortal.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FoodPortal.Interfaces
{
    public interface IAddOnsDetailService
    {
        Task<List<AddOnsDetail>> Add_AddOnsDetail(List<AddOnsDetail> AddOnsDetail);
        Task<AddOnsDetail?> Delete_AddOnsDetail(IdDTO idDTO);
        Task<AddOnsDetail?> Update_AddOnsDetail(AddOnsDetail AddOnsDetail);
        Task<AddOnsDetail?> View_AddOnsDetail(IdDTO idDTO);
        Task<List<AddOnsDetail>?> View_All_AddOnsDetails();
    }
}
