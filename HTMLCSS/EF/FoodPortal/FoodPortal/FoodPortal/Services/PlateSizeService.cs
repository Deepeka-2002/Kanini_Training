using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;

namespace FoodPortal.Services
{
    public class PlateSizeService: IPlateSizeService
    {
        private readonly ICrud<PlateSize, IdDTO> _plateSizeRepo;

        public PlateSizeService(ICrud<PlateSize, IdDTO> plateSizeRepo)
        {
            _plateSizeRepo = plateSizeRepo;
        }

        public async Task<PlateSize> Add_PlateSize(PlateSize PlateSize)
        {
            var PlateSizes = await _plateSizeRepo.GetAll();
            PlateSize empty = new PlateSize();

            var newPlateSize = PlateSizes.SingleOrDefault(h => h.Id == PlateSize.Id);
            if (newPlateSize == null)
            {
                var myPlateSize = await _plateSizeRepo.Add(PlateSize);
                if (myPlateSize != null)
                    return myPlateSize;
            }
            return empty;
        }

        public async Task<List<PlateSize>?> View_All_PlateSizes()
        {
            var PlateSizes = await _plateSizeRepo.GetAll();
            /*if (PlateSizes != null)*/
                return PlateSizes;
            /*return null;*/
        }

        //Get a Particular PlateSize
        public async Task<PlateSize?> View_PlateSize(IdDTO idDTO)
        {
            var PlateSize = await _plateSizeRepo.GetValue(idDTO);
            /*if (PlateSize != null)*/
                return PlateSize;
           /* return null;*/
        }

        //Delete a PlateSize
        public async Task<PlateSize?> Delete_PlateSize(IdDTO idDTO)
        {
            var PlateSize = await _plateSizeRepo.Delete(idDTO);
            /*if (PlateSize != null)*/
                return PlateSize;
            /*return null;*/
        }

        //Update a PlateSize
        public async Task<PlateSize?> Update_PlateSize(PlateSize PlateSize)
        {
            var myPlateSize = await _plateSizeRepo.Update(PlateSize);
            /*if (myPlateSize != null)*/
                return myPlateSize;
            /*return null;*/
        }
    }
}
