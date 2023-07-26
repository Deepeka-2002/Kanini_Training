using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;

namespace FoodPortal.Services
{
    public class AddOnsMasterService: IAddOnsMasterService
    {
        private readonly ICrud<AddOnsMaster, IdDTO> _AddOnsMasterRepo;

        public AddOnsMasterService(ICrud<AddOnsMaster, IdDTO> AddOnsMasterRepo)
        {
            _AddOnsMasterRepo = AddOnsMasterRepo;
        }

        public async Task<AddOnsMaster> Add_AddOnsMaster(AddOnsMaster AddOnsMaster)
        {
            var AddOnsMasters = await _AddOnsMasterRepo.GetAll();
            AddOnsMaster empty = new AddOnsMaster();

            var newAddOnsMaster = AddOnsMasters.SingleOrDefault(h => h.Id == AddOnsMaster.Id);
            if (newAddOnsMaster == null)
            {
                var myAddOnsMaster = await _AddOnsMasterRepo.Add(AddOnsMaster);
                if (myAddOnsMaster != null)
                    return myAddOnsMaster;
            }
            return empty;
        }

        public async Task<List<AddOnsMaster>?> View_All_AddOnsMasters()
        {
            var AddOnsMasters = await _AddOnsMasterRepo.GetAll();
            /*if (AddOnsMasters != null)*/
                return AddOnsMasters;
           /* return null;*/
        }

        //Get a Particular AddOnsMaster
        public async Task<AddOnsMaster?> View_AddOnsMaster(IdDTO idDTO)
        {
            var AddOnsMaster = await _AddOnsMasterRepo.GetValue(idDTO);
           /* if (AddOnsMaster != null)*/
                return AddOnsMaster;
           /* return null;*/
        }

        //Delete a AddOnsMaster
        public async Task<AddOnsMaster?> Delete_AddOnsMaster(IdDTO idDTO)
        {
            var AddOnsMaster = await _AddOnsMasterRepo.Delete(idDTO);
           /* if (AddOnsMaster != null)*/
                return AddOnsMaster;
            /*return null;*/
        }

        //Update a AddOnsMaster
        public async Task<AddOnsMaster?> Update_AddOnsMaster(AddOnsMaster AddOnsMaster)
        {
            var myAddOnsMaster = await _AddOnsMasterRepo.Update(AddOnsMaster);
            /*if (myAddOnsMaster != null)*/
                return myAddOnsMaster;
           /* return null;*/
        }

    }
}
