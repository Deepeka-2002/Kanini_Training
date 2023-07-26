using FoodPortal.Models;
using FoodPortal.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FoodPortal.Interfaces
{
    public interface ITimeSlotService
    {
        Task<TimeSlot> Add_TimeSlot(TimeSlot TimeSlot);

        Task<TimeSlot?> Delete_TimeSlot(IdDTO idDTO);

        Task<TimeSlot?> Update_TimeSlot(TimeSlot TimeSlot);
        Task<TimeSlot?> View_TimeSlot(IdDTO idDTO);
        Task<List<TimeSlot>?> View_All_TimeSlots();

    }
}
