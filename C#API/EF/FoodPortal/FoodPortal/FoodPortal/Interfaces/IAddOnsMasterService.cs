using FoodPortal.Models;
using FoodPortal.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FoodPortal.Interfaces
{
    public interface IAddOnsMasterService
    {
        Task<AddOnsMaster> Add_AddOnsMaster(AddOnsMaster AddOnsMaster);

        Task<AddOnsMaster?> Delete_AddOnsMaster(IdDTO idDTO);
        Task<AddOnsMaster?> Update_AddOnsMaster(AddOnsMaster AddOnsMaster);
        Task<AddOnsMaster?> View_AddOnsMaster(IdDTO idDTO);
        Task<List<AddOnsMaster>?> View_All_AddOnsMasters();
    }
}
