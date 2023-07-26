using FoodPortal.Models;
using FoodPortal.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FoodPortal.Interfaces
{
    public interface IGroupSizeService
    {
        Task<GroupSize> Add_GroupSize(GroupSize GroupSize);
        Task<GroupSize?> Delete_GroupSize(IdDTO idDTO);

        Task<GroupSize?> Update_GroupSize(GroupSize GroupSize);

        Task<GroupSize?> View_GroupSize(IdDTO idDTO);

        Task<List<GroupSize>?> View_All_GroupSizes();

    }
}
