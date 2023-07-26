using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;

namespace FoodPortal.Services
{
    public class AllergyMasterService : IAllergyMasterService
    {

        private readonly ICrud<AllergyMaster, IdDTO> _AllergyMasterRepo;

        public AllergyMasterService(ICrud<AllergyMaster, IdDTO> AllergyMasterRepo)
        {
            _AllergyMasterRepo = AllergyMasterRepo;
        }

        public async Task<AllergyMaster> Add_AllergyMaster(AllergyMaster AllergyMaster)

        {
            var AllergyMasters = await _AllergyMasterRepo.GetAll();
            AllergyMaster empty = new AllergyMaster();
            var newAllergyMaster = AllergyMasters.SingleOrDefault(h => h.Id == AllergyMaster.Id);
            if (newAllergyMaster == null)
            {
                var myAllergyMaster = await _AllergyMasterRepo.Add(AllergyMaster);
                if (myAllergyMaster != null)
                    return myAllergyMaster;
            }
            return empty;
        }

        public async Task<List<AllergyMaster>?> View_All_AllergyMasters()

        {
            var AllergyMasters = await _AllergyMasterRepo.GetAll();
            /* if (AllergyMasters != null)*/
            return AllergyMasters;
            /* return null;*/
        }

        //Get a Particular AllergyMaster
        public async Task<AllergyMaster?> View_AllergyMaster(IdDTO idDTO)
        {
            var AllergyMaster = await _AllergyMasterRepo.GetValue(idDTO);
            return AllergyMaster;
        }

        //Delete a AllergyMaster
        public async Task<AllergyMaster?> Delete_AllergyMaster(IdDTO idDTO)

        {
            var AllergyMaster = await _AllergyMasterRepo.Delete(idDTO);
            /* if (AllergyMaster != null)*/
            return AllergyMaster;
            /*return null;*/
        }

        //Update a AllergyMaster
        public async Task<AllergyMaster?> Update_AllergyMaster(AllergyMaster AllergyMaster)
        {
            var myAllergyMaster = await _AllergyMasterRepo.Update(AllergyMaster);
            /*if (myAllergyMaster != null)*/
            return myAllergyMaster;
            /*return null;*/
        }
    }
}
