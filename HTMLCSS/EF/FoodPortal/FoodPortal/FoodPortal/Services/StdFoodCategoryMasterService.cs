using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;

namespace FoodPortal.Services
{
    public class StdFoodCategoryMasterService: IStdFoodCategoryMasterService
    {
        private readonly ICrud<StdFoodCategoryMaster, IdDTO> _stdFoodCategoryMasterRepo;

        public StdFoodCategoryMasterService(ICrud<StdFoodCategoryMaster, IdDTO> stdFoodCategoryMasterRepo)
        {
            _stdFoodCategoryMasterRepo = stdFoodCategoryMasterRepo;
        }

        public async Task<StdFoodCategoryMaster> Add_StdFoodCategoryMaster(StdFoodCategoryMaster StdFoodCategoryMaster)
        {
            var StdFoodCategoryMasters = await _stdFoodCategoryMasterRepo.GetAll();
            StdFoodCategoryMaster empty = new StdFoodCategoryMaster();

            var newStdFoodCategoryMaster = StdFoodCategoryMasters.SingleOrDefault(h => h.Id == StdFoodCategoryMaster.Id);
            if (newStdFoodCategoryMaster == null)
            {
                var myStdFoodCategoryMaster = await _stdFoodCategoryMasterRepo.Add(StdFoodCategoryMaster);
                if (myStdFoodCategoryMaster != null)
                    return myStdFoodCategoryMaster;
            }
            return empty;
        }

        public async Task<List<StdFoodCategoryMaster>?> View_All_StdFoodCategoryMasters()
        {
            var StdFoodCategoryMasters = await _stdFoodCategoryMasterRepo.GetAll();
           /* if (StdFoodCategoryMasters != null)*/
                return StdFoodCategoryMasters;
            /*return null;*/
        }

        //Get a Particular StdFoodCategoryMaster
        public async Task<StdFoodCategoryMaster?> View_StdFoodCategoryMaster(IdDTO idDTO)
        {
            var StdFoodCategoryMaster = await _stdFoodCategoryMasterRepo.GetValue(idDTO);
           /* if (StdFoodCategoryMaster != null)*/
                return StdFoodCategoryMaster;
           /* return null;*/
        }

        //Delete a StdFoodCategoryMaster
        public async Task<StdFoodCategoryMaster?> Delete_StdFoodCategoryMaster(IdDTO idDTO)
        {
            var StdFoodCategoryMaster = await _stdFoodCategoryMasterRepo.Delete(idDTO);
           /* if (StdFoodCategoryMaster != null)*/
                return StdFoodCategoryMaster;
            /*return null;*/
        }

        //Update a StdFoodCategoryMaster
        public async Task<StdFoodCategoryMaster?> Update_StdFoodCategoryMaster(StdFoodCategoryMaster StdFoodCategoryMaster)
        {
            var myStdFoodCategoryMaster = await _stdFoodCategoryMasterRepo.Update(StdFoodCategoryMaster);
            /*if (myStdFoodCategoryMaster != null)*/
                return myStdFoodCategoryMaster;
           /* return null;*/
        }
    }
}
