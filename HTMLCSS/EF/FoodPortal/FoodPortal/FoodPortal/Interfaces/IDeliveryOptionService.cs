using FoodPortal.Models;
using FoodPortal.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FoodPortal.Interfaces
{
    public interface IDeliveryOptionService
    {
        Task<DeliveryOption> Add_DeliveryOption(DeliveryOption DeliveryOption);
        Task<DeliveryOption?> Delete_DeliveryOption(IdDTO idDTO);
        Task<DeliveryOption?> Update_DeliveryOption(DeliveryOption DeliveryOption);
        Task<DeliveryOption?> View_DeliveryOption(IdDTO idDTO);
        Task<List<DeliveryOption>?> View_All_DeliveryOptions();
    }
}
