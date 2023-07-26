using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;

namespace FoodPortal.Services
{
    public class TimeSlotService: ITimeSlotService
    {
        private readonly ICrud<TimeSlot, IdDTO> _timeSlotRepo;

        public TimeSlotService(ICrud<TimeSlot, IdDTO> timeSlotRepo)
        {
            _timeSlotRepo = timeSlotRepo;
        }

        public async Task<TimeSlot> Add_TimeSlot(TimeSlot TimeSlot)
        {
            var TimeSlots = await _timeSlotRepo.GetAll();
            TimeSlot empty = new TimeSlot();

            var newTimeSlot = TimeSlots.SingleOrDefault(h => h.Id == TimeSlot.Id);
            if (newTimeSlot == null)
            {
                var myTimeSlot = await _timeSlotRepo.Add(TimeSlot);
                if (myTimeSlot != null)
                    return myTimeSlot;
            }
            return empty;
        }

        public async Task<List<TimeSlot>?> View_All_TimeSlots()
        {
            var TimeSlots = await _timeSlotRepo.GetAll();
           /* if (TimeSlots != null)*/
                return TimeSlots;
           /* return null;*/
        }

        //Get a Particular TimeSlot
        public async Task<TimeSlot?> View_TimeSlot(IdDTO idDTO)
        {
            var TimeSlot = await _timeSlotRepo.GetValue(idDTO);
           /* if (TimeSlot != null)*/
                return TimeSlot;
           /* return null;*/
        }

        //Delete a TimeSlot
        public async Task<TimeSlot?> Delete_TimeSlot(IdDTO idDTO)
        {
            var TimeSlot = await _timeSlotRepo.Delete(idDTO);
            /*if (TimeSlot != null)*/
                return TimeSlot;
            /*return null;*/
        }

        //Update a TimeSlot
        public async Task<TimeSlot?> Update_TimeSlot(TimeSlot TimeSlot)
        {
            var myTimeSlot = await _timeSlotRepo.Update(TimeSlot);
            /*if (myTimeSlot != null)*/
                return myTimeSlot;
            /*return null;*/
        }
    }
}
