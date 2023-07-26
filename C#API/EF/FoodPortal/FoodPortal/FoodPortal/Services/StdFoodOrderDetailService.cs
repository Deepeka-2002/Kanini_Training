using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;

namespace FoodPortal.Services
{
    public class StdFoodOrderDetailService: IStdFoodOrderDetailService
    {
        private readonly ICrud<StdFoodOrderDetail, IdDTO> _stdFoodOrderDetailRepo;

        public StdFoodOrderDetailService(ICrud<StdFoodOrderDetail, IdDTO> stdFoodOrderDetailRepo)
        {
            _stdFoodOrderDetailRepo = stdFoodOrderDetailRepo;
        }

        public async Task<List<StdFoodOrderDetail>> Add_StdFoodOrderDetail(List<StdFoodOrderDetail> StdFoodOrderDetail)

        {

            List<StdFoodOrderDetail> addedStdFoodOrderDetails = new List<StdFoodOrderDetail>();

            var StdFoodOrderDetails = await _stdFoodOrderDetailRepo.GetAll();

            foreach (var stdFoodOrderDetail in StdFoodOrderDetail)
            {

                Console.WriteLine(stdFoodOrderDetail);

                
                var myStdFoodOrderDetail = await _stdFoodOrderDetailRepo.Add(stdFoodOrderDetail);

                    if (myStdFoodOrderDetail != null)
                    {
                        addedStdFoodOrderDetails.Add(myStdFoodOrderDetail);
                    }
                
            }
            return addedStdFoodOrderDetails;
        }

        public async Task<List<StdFoodOrderDetail>?> View_All_StdFoodOrderDetails()

        {
            var StdFoodOrderDetails = await _stdFoodOrderDetailRepo.GetAll();
           /* if (StdFoodOrderDetails != null)*/
                return StdFoodOrderDetails;
            /*return null;*/
        }

        //Get a Particular StdFoodOrderDetail
        public async Task<StdFoodOrderDetail?> View_StdFoodOrderDetail(IdDTO idDTO)
        {
            var StdFoodOrderDetail = await _stdFoodOrderDetailRepo.GetValue(idDTO);
           /* if (StdFoodOrderDetail != null)*/
                return StdFoodOrderDetail;
            /*return null;*/
        }

        //Delete a StdFoodOrderDetail
        public async Task<StdFoodOrderDetail?> Delete_StdFoodOrderDetail(IdDTO idDTO)

        {
            var StdFoodOrderDetail = await _stdFoodOrderDetailRepo.Delete(idDTO);
           /* if (StdFoodOrderDetail != null)*/
                return StdFoodOrderDetail;
           /* return null;*/
        }

        //Update a StdFoodOrderDetail
        public async Task<StdFoodOrderDetail?> Update_StdFoodOrderDetail(StdFoodOrderDetail StdFoodOrderDetail)
        {
            var myStdFoodOrderDetail = await _stdFoodOrderDetailRepo.Update(StdFoodOrderDetail);
            /*if (myStdFoodOrderDetail != null)*/
                return myStdFoodOrderDetail;
            /*return null;*/
        }
    }
}
