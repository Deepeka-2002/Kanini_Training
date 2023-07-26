using FoodPortal.Models;
using FoodPortal.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FoodPortal.Interfaces
{
    public interface IOrderService
    {
        Task<Order> Add_Order(Order Order);
        Task<Order?> Delete_Order(IdDTO idDTO);
        Task<Order?> Update_Order(Order Order);
        Task<Order?> View_Order(IdDTO idDTO);
        Task<List<Order>?> View_All_Orders();
        Task<List<AvailabilityDTO>> GetUnAvailableDate(DateTime date);
        Task<List<AvailabilityDTO>> GetAvailableTimeSlot(DateTime date);
    }
}
