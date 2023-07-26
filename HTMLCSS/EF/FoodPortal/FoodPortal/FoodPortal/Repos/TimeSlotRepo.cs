using FoodPortal.Exceptions;
using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FoodPortal.Repos
{
    public class TimeSlotRepo : ICrud<TimeSlot, IdDTO>
    {
        private readonly FoodPortalContext _context;

        public TimeSlotRepo(FoodPortalContext context)
        {
            _context = context;
        }
        public async Task<TimeSlot?> Add(TimeSlot item)
        {
            try
            {
                var newTimeSlot = _context.TimeSlots.SingleOrDefault(h => h.Id == item.Id);
                if (newTimeSlot == null)
                {
                    await _context.TimeSlots.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
                return null;
            }

            catch (SqlException se)
            {
                throw new InvalidSqlException(se.Message);
            }
        }

        public async Task<TimeSlot?> Delete(IdDTO item)
        {
            try
            {
                /*var rooms = _context.Rooms.ToList();
                var myRooms = rooms.Where(r => r.H_id == item.ID);
                foreach (var value in myRooms)
                {
                    _context.Rooms.Remove(value);
                    _context.SaveChanges();
                }*/
                var TimeSlots = await _context.TimeSlots.ToListAsync();
                var myTimeSlot = TimeSlots.FirstOrDefault(h => h.Id == item.IdInt);
                if (myTimeSlot != null)
                {
                    _context.TimeSlots.Remove(myTimeSlot);
                    await _context.SaveChangesAsync();
                    return myTimeSlot;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<TimeSlot>?> GetAll()
        {
            try
            {
                var TimeSlots = await _context.TimeSlots.ToListAsync();
                if (TimeSlots != null)
                    return TimeSlots;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<TimeSlot?> GetValue(IdDTO item)
        {
            try
            {
                var TimeSlots = await _context.TimeSlots.ToListAsync();
                var TimeSlot = TimeSlots.SingleOrDefault(h => h.Id == item.IdInt);
                if (TimeSlot != null)
                    return TimeSlot;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<TimeSlot?> Update(TimeSlot item)
        {
            try
            {
                var TimeSlots = await _context.TimeSlots.ToListAsync();
                var TimeSlot = TimeSlots.SingleOrDefault(h => h.Id == item.Id);
                if (TimeSlot != null)
                {
                    TimeSlot.AddTimeSlot = item.AddTimeSlot != null ? item.AddTimeSlot : TimeSlot.AddTimeSlot;
                    TimeSlot.StartTime = item.StartTime != null ? item.StartTime : TimeSlot.StartTime;

                    _context.TimeSlots.Update(TimeSlot);
                    await _context.SaveChangesAsync();
                    return TimeSlot;
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }
    }
}
