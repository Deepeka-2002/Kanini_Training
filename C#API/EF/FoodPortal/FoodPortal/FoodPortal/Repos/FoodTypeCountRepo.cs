using FoodPortal.Exceptions;
using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FoodPortal.Repos
{
    public class FoodTypeCountRepo : ICrud<FoodTypeCount, IdDTO>
    {
        private readonly FoodPortalContext _context;

        public FoodTypeCountRepo(FoodPortalContext context)
        {
            _context = context;
        }
        public async Task<FoodTypeCount?> Add(FoodTypeCount item)
        {
            try
            {
                var plateSizeExists = await _context.PlateSizes.AnyAsync(c => c.Id == item.PlateSizeId);
                if (!plateSizeExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }
                var orderExists = await _context.Orders.AnyAsync(c => c.Id == item.OrderId);
                if (!orderExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }
                var newFoodTypeCount = _context.FoodTypeCounts.FirstOrDefault(h => h.Id == item.Id);
                if (newFoodTypeCount == null)
                {
                    await _context.FoodTypeCounts.AddAsync(item);
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

        public async Task<FoodTypeCount?> Delete(IdDTO item)
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
                var FoodTypeCounts = await _context.FoodTypeCounts.ToListAsync();
                var myFoodTypeCount = FoodTypeCounts.FirstOrDefault(h => h.Id == item.IdInt);
                if (myFoodTypeCount != null)
                {
                    _context.FoodTypeCounts.Remove(myFoodTypeCount);
                    await _context.SaveChangesAsync();
                    return myFoodTypeCount;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<FoodTypeCount>?> GetAll()
        {
            try
            {
                var FoodTypeCounts = await _context.FoodTypeCounts.ToListAsync();
                if (FoodTypeCounts != null)
                    return FoodTypeCounts;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<FoodTypeCount?> GetValue(IdDTO item)
        {
            try
            {
                var FoodTypeCounts = await _context.FoodTypeCounts.ToListAsync();
                var FoodTypeCount = FoodTypeCounts.SingleOrDefault(h => h.Id == item.IdInt);
                if (FoodTypeCount != null)
                    return FoodTypeCount;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<FoodTypeCount?> Update(FoodTypeCount item)
        {
            try
            {
                var plateSizeExists = await _context.PlateSizes.AnyAsync(c => c.Id == item.PlateSizeId);
                if (!plateSizeExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }
                var orderExists = await _context.Orders.AnyAsync(c => c.Id == item.OrderId);
                if (!orderExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }
                var FoodTypeCounts = await _context.FoodTypeCounts.ToListAsync();
                var FoodTypeCount = FoodTypeCounts.SingleOrDefault(h => h.Id == item.Id);
                if (FoodTypeCount != null)
                {
                    FoodTypeCount.OrderId = item.OrderId != null ? item.OrderId : FoodTypeCount.OrderId;
                    FoodTypeCount.FoodTypeCount1 = item.FoodTypeCount1 != null ? item.FoodTypeCount1 : FoodTypeCount.FoodTypeCount1;
                    FoodTypeCount.IsVeg = item.IsVeg != null ? item.IsVeg : FoodTypeCount.IsVeg;
                    FoodTypeCount.PlateSizeId = item.PlateSizeId != null ? item.PlateSizeId : FoodTypeCount.PlateSizeId;

                    _context.FoodTypeCounts.Update(FoodTypeCount);
                    await _context.SaveChangesAsync();
                    return FoodTypeCount;
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
