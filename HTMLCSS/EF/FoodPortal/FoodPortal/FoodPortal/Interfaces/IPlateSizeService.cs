using FoodPortal.Models;
using FoodPortal.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FoodPortal.Interfaces
{
    public interface IPlateSizeService
    {
        Task<PlateSize> Add_PlateSize(PlateSize PlateSize);
        Task<PlateSize?> Delete_PlateSize(IdDTO idDTO);
        Task<PlateSize?> Update_PlateSize(PlateSize PlateSize);
        Task<PlateSize?> View_PlateSize(IdDTO idDTO);
        Task<List<PlateSize>?> View_All_PlateSizes();
    }
}
