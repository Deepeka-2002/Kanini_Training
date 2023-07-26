using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using FoodPortal.Repos;

namespace FoodPortal.Services
{
    public class AdditionalProductsDetailService : IAdditionalProductsDetailService
    {

        private readonly ICrud<AdditionalProductsDetail, IdDTO> _additionalProductsDetailRepo;

        public AdditionalProductsDetailService(ICrud<AdditionalProductsDetail, IdDTO> additionalProductsDetailRepo)
        {
            _additionalProductsDetailRepo = additionalProductsDetailRepo;
        }

        public async Task<List<AdditionalProductsDetail>> Add_AdditionalProductsDetail(List<AdditionalProductsDetail> AdditionalProductsDetail)
        {

            List<AdditionalProductsDetail> addedAdditionalProductsDetail = new List<AdditionalProductsDetail>();

            var AdditionalProductsDetails = await _additionalProductsDetailRepo.GetAll();

            foreach (var additionalProductsDetail in AdditionalProductsDetail)
            {

                Console.WriteLine(additionalProductsDetail);

                var myAdditionalProductsDetail = await _additionalProductsDetailRepo.Add(additionalProductsDetail);

                if (myAdditionalProductsDetail != null)
                {
                    addedAdditionalProductsDetail.Add(myAdditionalProductsDetail);
                }
                
            }
            return addedAdditionalProductsDetail;

        }

        public async Task<List<AdditionalProductsDetail>?> View_All_AdditionalProductsDetails()

        {
            var AdditionalProductsDetails = await _additionalProductsDetailRepo.GetAll();
            /*if (AdditionalProductsDetails != null)*/
                return AdditionalProductsDetails;
           /* return null;*/
        }

        //Get a Particular AdditionalProductsDetail
        public async Task<AdditionalProductsDetail?> View_AdditionalProductsDetail(IdDTO idDTO)
        {
            var AdditionalProductsDetail = await _additionalProductsDetailRepo.GetValue(idDTO);
            /*if (AdditionalProductsDetail != null)*/
                return AdditionalProductsDetail;
            /*return null;*/
        }

        //Delete a AdditionalProductsDetail
        public async Task<AdditionalProductsDetail?> Delete_AdditionalProductsDetail(IdDTO idDTO)

        {
            var AdditionalProductsDetail = await _additionalProductsDetailRepo.Delete(idDTO);
            /*if (AdditionalProductsDetail != null)*/
                return AdditionalProductsDetail;
            /*return null;*/
        }

        //Update a AdditionalProductsDetail
        public async Task<AdditionalProductsDetail?> Update_AdditionalProductsDetail(AdditionalProductsDetail AdditionalProductsDetail)
        {
            var myAdditionalProductsDetail = await _additionalProductsDetailRepo.Update(AdditionalProductsDetail);
            /*if (myAdditionalProductsDetail != null)*/
                return myAdditionalProductsDetail;
           /* return null;*/
        }
    }
}
