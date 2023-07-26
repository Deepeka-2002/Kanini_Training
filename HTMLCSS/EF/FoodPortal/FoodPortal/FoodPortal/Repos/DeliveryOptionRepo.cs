using FoodPortal.Exceptions;
using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FoodPortal.Repos
{
    public class DeliveryOptionRepo : ICrud<DeliveryOption, IdDTO>
    {
        private readonly FoodPortalContext _context;

        public DeliveryOptionRepo(FoodPortalContext context)
        {
            _context = context;
        }
        public async Task<DeliveryOption?> Add(DeliveryOption item)
        {
            try
            {
                var newDeliveryOption = _context.DeliveryOptions.SingleOrDefault(h => h.Id == item.Id);
                if (newDeliveryOption == null)
                {
                    await _context.DeliveryOptions.AddAsync(item);
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

        public async Task<DeliveryOption?> Delete(IdDTO item)
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
                var DeliveryOptions = await _context.DeliveryOptions.ToListAsync();
                var myDeliveryOption = DeliveryOptions.FirstOrDefault(h => h.Id == item.IdInt);
                if (myDeliveryOption != null)
                {
                    _context.DeliveryOptions.Remove(myDeliveryOption);
                    await _context.SaveChangesAsync();
                    return myDeliveryOption;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<DeliveryOption>?> GetAll()
        {
            try
            {
                var DeliveryOptions = await _context.DeliveryOptions.ToListAsync();
                if (DeliveryOptions != null)
                    return DeliveryOptions;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<DeliveryOption?> GetValue(IdDTO item)
        {
            try
            {
                var DeliveryOptions = await _context.DeliveryOptions.ToListAsync();
                var DeliveryOption = DeliveryOptions.SingleOrDefault(h => h.Id == item.IdInt);
                if (DeliveryOption != null)
                    return DeliveryOption;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<DeliveryOption?> Update(DeliveryOption item)
        {
            try
            {
                var DeliveryOptions = await _context.DeliveryOptions.ToListAsync();
                var DeliveryOption = DeliveryOptions.SingleOrDefault(h => h.Id == item.Id);
                if (DeliveryOption != null)
                {
                    DeliveryOption.DeliveryOption1 = item.DeliveryOption1 != null ? item.DeliveryOption1 : DeliveryOption.DeliveryOption1;
                    _context.DeliveryOptions.Update(DeliveryOption);
                    await _context.SaveChangesAsync();
                    return DeliveryOption;
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
