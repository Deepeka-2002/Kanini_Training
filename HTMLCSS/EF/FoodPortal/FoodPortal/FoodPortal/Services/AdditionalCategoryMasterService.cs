using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;

namespace FoodPortal.Services
{
    public class AdditionalCategoryMasterService: IAdditionalCategoryMasterService
    {

        private readonly ICrud<AdditionalCategoryMaster, IdDTO> _additionalCategoryMasterRepo;

        public AdditionalCategoryMasterService(ICrud<AdditionalCategoryMaster, IdDTO> AdditionalCategoryMasterRepo)
        {
            _additionalCategoryMasterRepo = AdditionalCategoryMasterRepo;
        }

        public async Task<AdditionalCategoryMaster> Add_AdditionalCategoryMaster(AdditionalCategoryMaster additionalCategoryMaster)

        {
            var AdditionalCategoryMasters = await _additionalCategoryMasterRepo.GetAll();
            AdditionalCategoryMaster empty = new AdditionalCategoryMaster();
            var newAdditionalCategoryMaster = AdditionalCategoryMasters.SingleOrDefault(h => h.Id == additionalCategoryMaster.Id);
            if (newAdditionalCategoryMaster == null)
            {
                var myAdditionalCategoryMaster = await _additionalCategoryMasterRepo.Add(additionalCategoryMaster);
                if (myAdditionalCategoryMaster != null)
                    return myAdditionalCategoryMaster;
            }
            return empty;
        }

        public async Task<List<AdditionalCategoryMaster>?> View_All_AdditionalCategoryMasters()

        {
            var AdditionalCategoryMasters = await _additionalCategoryMasterRepo.GetAll();
           /* if (AdditionalCategoryMasters != null)*/
                return AdditionalCategoryMasters;
           /* return null;*/
        }

        //Get a Particular AdditionalCategoryMaster
        public async Task<AdditionalCategoryMaster?> View_AdditionalCategoryMaster(IdDTO idDTO)
        {
            var AdditionalCategoryMaster = await _additionalCategoryMasterRepo.GetValue(idDTO);
            return AdditionalCategoryMaster;
        }

        //Delete a AdditionalCategoryMaster
        public async Task<AdditionalCategoryMaster?> Delete_AdditionalCategoryMaster(IdDTO idDTO)

        {
            var AdditionalCategoryMaster = await _additionalCategoryMasterRepo.Delete(idDTO);
           /* if (AdditionalCategoryMaster != null)*/
                return AdditionalCategoryMaster;
            /*return null;*/
        }

        //Update a AdditionalCategoryMaster
        public async Task<AdditionalCategoryMaster?> Update_AdditionalCategoryMaster(AdditionalCategoryMaster additionalCategoryMaster)
        {
            var myAdditionalCategoryMaster = await _additionalCategoryMasterRepo.Update(additionalCategoryMaster);
            /*if (myAdditionalCategoryMaster != null)*/
                return myAdditionalCategoryMaster;
            /*return null;*/
        }
    }
}
