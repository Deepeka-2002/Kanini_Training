using FoodPortal.Exceptions;
using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FoodPortal.Repos
{
    public class StdFoodCategoryMasterRepo : ICrud<StdFoodCategoryMaster, IdDTO>
    {
        private readonly FoodPortalContext _context;

        public StdFoodCategoryMasterRepo(FoodPortalContext context)
        {
            _context = context;
        }
        public async Task<StdFoodCategoryMaster?> Add(StdFoodCategoryMaster item)
        {
            try
            {
                var newStdFoodCategoryMaster = _context.StdFoodCategoryMasters.SingleOrDefault(h => h.Id == item.Id);
                if (newStdFoodCategoryMaster == null)
                {
                    await _context.StdFoodCategoryMasters.AddAsync(item);
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

        public async Task<StdFoodCategoryMaster?> Delete(IdDTO item)
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
                var StdFoodCategoryMasters = await _context.StdFoodCategoryMasters.ToListAsync();
                var myStdFoodCategoryMaster = StdFoodCategoryMasters.FirstOrDefault(h => h.Id == item.IdInt);
                if (myStdFoodCategoryMaster != null)
                {
                    _context.StdFoodCategoryMasters.Remove(myStdFoodCategoryMaster);
                    await _context.SaveChangesAsync();
                    return myStdFoodCategoryMaster;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<StdFoodCategoryMaster>?> GetAll()
        {
            try
            {
                var StdFoodCategoryMasters = await _context.StdFoodCategoryMasters.ToListAsync();
                if (StdFoodCategoryMasters != null)
                    return StdFoodCategoryMasters;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<StdFoodCategoryMaster?> GetValue(IdDTO item)
        {
            try
            {
                var StdFoodCategoryMasters = await _context.StdFoodCategoryMasters.ToListAsync();
                var StdFoodCategoryMaster = StdFoodCategoryMasters.SingleOrDefault(h => h.Id == item.IdInt);
                if (StdFoodCategoryMaster != null)
                    return StdFoodCategoryMaster;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<StdFoodCategoryMaster?> Update(StdFoodCategoryMaster item)
        {
            try
            {
                var StdFoodCategoryMasters = await _context.StdFoodCategoryMasters.ToListAsync();
                var StdFoodCategoryMaster = StdFoodCategoryMasters.SingleOrDefault(h => h.Id == item.Id);
                if (StdFoodCategoryMaster != null)
                {
                    StdFoodCategoryMaster.Category = item.Category != null ? item.Category : StdFoodCategoryMaster.Category;
                    _context.StdFoodCategoryMasters.Update(StdFoodCategoryMaster);
                    await _context.SaveChangesAsync();
                    return StdFoodCategoryMaster;
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
