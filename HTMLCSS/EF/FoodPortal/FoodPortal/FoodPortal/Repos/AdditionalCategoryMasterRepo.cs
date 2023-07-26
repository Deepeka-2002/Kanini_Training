using FoodPortal.Exceptions;
using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FoodPortal.Repos
{
    public class AdditionalCategoryMasterRepo : ICrud<AdditionalCategoryMaster, IdDTO>
    {

        private readonly FoodPortalContext _context;

        public AdditionalCategoryMasterRepo(FoodPortalContext context)
        {
            _context = context;
        }
        public async Task<AdditionalCategoryMaster?> Add(AdditionalCategoryMaster item)
        {
            try
            {
                var newAdditionalCategoryMaster = _context.AdditionalCategoryMasters.FirstOrDefault(h => h.Id == item.Id);
                if (newAdditionalCategoryMaster == null)
                {
                    await _context.AdditionalCategoryMasters.AddAsync(item);
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

        public async Task<AdditionalCategoryMaster?> Delete(IdDTO item)
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
                var additionalCategoryMasters = await _context.AdditionalCategoryMasters.ToListAsync();
                var myAdditionalCategoryMaster = additionalCategoryMasters.FirstOrDefault(h => h.Id == item.IdInt);
                if (myAdditionalCategoryMaster != null)
                {
                    _context.AdditionalCategoryMasters.Remove(myAdditionalCategoryMaster);
                    await _context.SaveChangesAsync();
                    return myAdditionalCategoryMaster;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<AdditionalCategoryMaster>?> GetAll()
        {
            try
            {
                var additionalCategoryMasters = await _context.AdditionalCategoryMasters.ToListAsync();
                if (additionalCategoryMasters != null)
                    return additionalCategoryMasters;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<AdditionalCategoryMaster?> GetValue(IdDTO item)
        {
            try
            {
                var additionalCategoryMasters = await _context.AdditionalCategoryMasters.ToListAsync();
                var additionalCategoryMaster = additionalCategoryMasters.SingleOrDefault(h => h.Id == item.IdInt);
                if (additionalCategoryMaster != null)
                    return additionalCategoryMaster;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<AdditionalCategoryMaster?> Update(AdditionalCategoryMaster item)
        {
            try
            {
                var additionalCategoryMasters = await _context.AdditionalCategoryMasters.ToListAsync();
                var additionalCategoryMaster = additionalCategoryMasters.SingleOrDefault(h => h.Id == item.Id);
                if (additionalCategoryMaster != null)
                {
                    additionalCategoryMaster.AdditionalCategory = item.AdditionalCategory != null ? item.AdditionalCategory : additionalCategoryMaster.AdditionalCategory;
                    _context.AdditionalCategoryMasters.Update(additionalCategoryMaster);
                    await _context.SaveChangesAsync();
                    return additionalCategoryMaster;
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
