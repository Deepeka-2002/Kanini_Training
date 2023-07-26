using FoodPortal.Exceptions;
using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FoodPortal.Repos
{
    public class TrackStatusRepo : ICrud<TrackStatus, IdDTO>
    {
        private readonly FoodPortalContext _context;

        public TrackStatusRepo(FoodPortalContext context)
        {
            _context = context;
        }
        public async Task<TrackStatus?> Add(TrackStatus item)
        {
            try
            {
                var orderExists = await _context.Orders.AnyAsync(c => c.Id == item.OrderId);
                if (!orderExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }
                var newTrackStatus = _context.TrackStatuses.FirstOrDefault(h => h.Id == item.Id);
                if (newTrackStatus == null)
                {
                    await _context.TrackStatuses.AddAsync(item);
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

        public async Task<TrackStatus?> Delete(IdDTO item)
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
                var TrackStatuss = await _context.TrackStatuses.ToListAsync();
                var myTrackStatus = TrackStatuss.FirstOrDefault(h => h.Id == item.IdString);
                if (myTrackStatus != null)
                {
                    _context.TrackStatuses.Remove(myTrackStatus);
                    await _context.SaveChangesAsync();
                    return myTrackStatus;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<TrackStatus>?> GetAll()
        {
            try
            {
                var TrackStatuss = await _context.TrackStatuses.ToListAsync();
                if (TrackStatuss != null)
                    return TrackStatuss;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<TrackStatus?> GetValue(IdDTO item)
        {
            try
            {
                var TrackStatuss = await _context.TrackStatuses.ToListAsync();
                var TrackStatus = TrackStatuss.SingleOrDefault(h => h.Id == item.IdString);
                if (TrackStatus != null)
                    return TrackStatus;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<TrackStatus?> Update(TrackStatus item)
        {
            try
            {
                var orderExists = await _context.Orders.AnyAsync(c => c.Id == item.OrderId);
                if (!orderExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }
                var TrackStatuss = await _context.TrackStatuses.ToListAsync();
                var TrackStatus = TrackStatuss.SingleOrDefault(h => h.Id == item.Id);
                if (TrackStatus != null)
                {
                    TrackStatus.OrderId = item.OrderId != null ? item.OrderId : TrackStatus.OrderId;
                    TrackStatus.Status = item.Status != null ? item.Status : TrackStatus.Status;

                    _context.TrackStatuses.Update(TrackStatus);
                    await _context.SaveChangesAsync();
                    return TrackStatus;
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
