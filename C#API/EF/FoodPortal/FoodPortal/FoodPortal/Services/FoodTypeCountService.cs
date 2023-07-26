using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using FoodPortal.Repos;

namespace FoodPortal.Services
{
    public class FoodTypeCountService : IFoodTypeCountService
    {
        private readonly ICrud<FoodTypeCount, IdDTO> _FoodTypeCountRepo;

        public FoodTypeCountService(ICrud<FoodTypeCount, IdDTO> FoodTypeCountRepo)
        {
            _FoodTypeCountRepo = FoodTypeCountRepo;
        }

        public async Task<List<FoodTypeCount>> Add_FoodTypeCount(List<FoodTypeCount> FoodTypeCount)
        {
            

            List<FoodTypeCount> addedFoodTypeCount = new List<FoodTypeCount>();

            var FoodTypeCounts = await _FoodTypeCountRepo.GetAll();

            foreach (var foodTypeCount in FoodTypeCount)
            {

                Console.WriteLine(foodTypeCount);

                
                var myFoodTypeCount = await _FoodTypeCountRepo.Add(foodTypeCount);

                if (myFoodTypeCount != null)
                {
                    addedFoodTypeCount.Add(myFoodTypeCount);
                }
               
            }
            return addedFoodTypeCount;

        }

        public async Task<List<FoodTypeCount>?> View_All_FoodTypeCounts()

        {
            var FoodTypeCounts = await _FoodTypeCountRepo.GetAll();
           /* if (FoodTypeCounts != null)*/
                return FoodTypeCounts;
           /* return null;*/
        }

        //Get a Particular FoodTypeCount
        public async Task<FoodTypeCount?> View_FoodTypeCount(IdDTO idDTO)
        {
            var FoodTypeCount = await _FoodTypeCountRepo.GetValue(idDTO);
            /*if (FoodTypeCount != null)*/
                return FoodTypeCount;
           /* return null;*/
        }

        //Delete a FoodTypeCount
        public async Task<FoodTypeCount?> Delete_FoodTypeCount(IdDTO idDTO)

        {
            var FoodTypeCount = await _FoodTypeCountRepo.Delete(idDTO);
           /* if (FoodTypeCount != null)*/
                return FoodTypeCount;
           /* return null;*/
        }

        //Update a FoodTypeCount
        public async Task<FoodTypeCount?> Update_FoodTypeCount(FoodTypeCount FoodTypeCount)
        {
            var myFoodTypeCount = await _FoodTypeCountRepo.Update(FoodTypeCount);
            /*if (myFoodTypeCount != null)*/
                return myFoodTypeCount;
          /*  return null;*/
        }
    }
}
