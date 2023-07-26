using FoodPortal.Models.DTO;
using FoodPortal.Models;

namespace FoodPortal.Interfaces
{
    public interface IAllergyMasterService
    {
        Task<AllergyMaster> Add_AllergyMaster(AllergyMaster AllergyMaster);

        Task<AllergyMaster?> Delete_AllergyMaster(IdDTO idDTO);

        Task<AllergyMaster?> Update_AllergyMaster(AllergyMaster AllergyMaster);
        Task<AllergyMaster?> View_AllergyMaster(IdDTO idDTO);

        Task<List<AllergyMaster>?> View_All_AllergyMasters();
    }
}
