using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;

namespace FoodPortal.Services
{
    public class DeliveryOptionService: IDeliveryOptionService
    {
        private readonly ICrud<DeliveryOption, IdDTO> _deliveryOptionRepo;

        public DeliveryOptionService(ICrud<DeliveryOption, IdDTO> deliveryOptionRepo)
        {
            _deliveryOptionRepo = deliveryOptionRepo;
        }

        public async Task<DeliveryOption> Add_DeliveryOption(DeliveryOption deliveryOption)
        {
            var DeliveryOptions = await _deliveryOptionRepo.GetAll();
            DeliveryOption empty = new DeliveryOption();
            var newDeliveryOption = DeliveryOptions.SingleOrDefault(h => h.Id == deliveryOption.Id);
            if (newDeliveryOption == null)
            {
                var myDeliveryOption = await _deliveryOptionRepo.Add(deliveryOption);
                if (myDeliveryOption != null)
                    return myDeliveryOption;
            }
            return empty;
        }

        public async Task<List<DeliveryOption>?> View_All_DeliveryOptions()
        {
            var DeliveryOptions = await _deliveryOptionRepo.GetAll();
            /*if (DeliveryOptions != null)*/
                return DeliveryOptions;
           /* return null;*/
        }

        //Get a Particular DeliveryOption
        public async Task<DeliveryOption?> View_DeliveryOption(IdDTO idDTO)
        {
            var DeliveryOption = await _deliveryOptionRepo.GetValue(idDTO);
           /* if (DeliveryOption != null)*/
                return DeliveryOption;
            /*return null;*/
        }

        //Delete a DeliveryOption
        public async Task<DeliveryOption?> Delete_DeliveryOption(IdDTO idDTO)
        {
            var DeliveryOption = await _deliveryOptionRepo.Delete(idDTO);
           /* if (DeliveryOption != null)*/
                return DeliveryOption;
           /* return null;*/
        }

        //Update a DeliveryOption
        public async Task<DeliveryOption?> Update_DeliveryOption(DeliveryOption DeliveryOption)
        {
            var myDeliveryOption = await _deliveryOptionRepo.Update(DeliveryOption);
            /*if (myDeliveryOption != null)*/
                return myDeliveryOption;
           /* return null;*/
        }

    }
}
