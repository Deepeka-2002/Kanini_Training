using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using FoodPortal.Repos;

namespace FoodPortal.Services
{
    public class AddOnsDetailService : IAddOnsDetailService
    {

        private readonly ICrud<AddOnsDetail, IdDTO> _addOnsDetailRepo;

        public AddOnsDetailService(ICrud<AddOnsDetail, IdDTO> addOnsDetailRepo)
        {
            _addOnsDetailRepo = addOnsDetailRepo;
        }

        public async Task<List<AddOnsDetail>> Add_AddOnsDetail(List<AddOnsDetail> AddOnsDetail)
        {
            

            List<AddOnsDetail> addedAddOnsDetail = new List<AddOnsDetail>();

            var AdditionalProductsDetails = await _addOnsDetailRepo.GetAll();

            foreach (var addOnsDetail in AddOnsDetail)
            {

                Console.WriteLine(addOnsDetail);

               
                var myAddOnsDetail = await _addOnsDetailRepo.Add(addOnsDetail);

                if (myAddOnsDetail != null)
                {
                    addedAddOnsDetail.Add(myAddOnsDetail);
                }
              
            }
            return addedAddOnsDetail;
        }

        public async Task<List<AddOnsDetail>?> View_All_AddOnsDetails()

        {
            var AddOnsDetails = await _addOnsDetailRepo.GetAll();
            /*if (AddOnsDetails != null)*/
                return AddOnsDetails;
            /*return null;*/
        }

        //Get a Particular AddOnsDetail
        public async Task<AddOnsDetail?> View_AddOnsDetail(IdDTO idDTO)
        {
            var AddOnsDetail = await _addOnsDetailRepo.GetValue(idDTO);
           /* if (AddOnsDetail != null)*/
                return AddOnsDetail;
            /*return null;*/
        }

        //Delete a AddOnsDetail
        public async Task<AddOnsDetail?> Delete_AddOnsDetail(IdDTO idDTO)

        {
            var AddOnsDetail = await _addOnsDetailRepo.Delete(idDTO);
            /*if (AddOnsDetail != null)*/
                return AddOnsDetail;
           /* return null;*/
        }

        //Update a AddOnsDetail
        public async Task<AddOnsDetail?> Update_AddOnsDetail(AddOnsDetail AddOnsDetail)
        {
            var myAddOnsDetail = await _addOnsDetailRepo.Update(AddOnsDetail);
            /*if (myAddOnsDetail != null)*/
                return myAddOnsDetail;
           /* return null;*/
        }
    }
}
