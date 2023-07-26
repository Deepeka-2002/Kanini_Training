using FoodPortal.Exceptions;
using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FoodPortal.Repos
{
    public class AllergyMasterRepo : ICrud<AllergyMaster, IdDTO>
    {

        private readonly FoodPortalContext _context;

        public AllergyMasterRepo(FoodPortalContext context)
        {
            _context = context;
        }
        public async Task<AllergyMaster?> Add(AllergyMaster item)
        {
            try
            {
                var newAllergyMaster = _context.AllergyMasters.FirstOrDefault(h => h.Id == item.Id);
                if (newAllergyMaster == null)
                {
                    await _context.AllergyMasters.AddAsync(item);
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

        public async Task<AllergyMaster?> Delete(IdDTO item)
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
                var AllergyMasters = await _context.AllergyMasters.ToListAsync();
                var myAllergyMaster = AllergyMasters.FirstOrDefault(h => h.Id == item.IdInt);
                if (myAllergyMaster != null)
                {
                    _context.AllergyMasters.Remove(myAllergyMaster);
                    await _context.SaveChangesAsync();
                    return myAllergyMaster;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<AllergyMaster>?> GetAll()
        {
            try
            {
                var AllergyMasters = await _context.AllergyMasters.ToListAsync();
                if (AllergyMasters != null)
                    return AllergyMasters;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<AllergyMaster?> GetValue(IdDTO item)
        {
            try
            {
                var AllergyMasters = await _context.AllergyMasters.ToListAsync();
                var AllergyMaster = AllergyMasters.SingleOrDefault(h => h.Id == item.IdInt);
                if (AllergyMaster != null)
                    return AllergyMaster;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<AllergyMaster?> Update(AllergyMaster item)
        {
            try
            {
                var AllergyMasters = await _context.AllergyMasters.ToListAsync();
                var AllergyMaster = AllergyMasters.SingleOrDefault(h => h.Id == item.Id);
                if (AllergyMaster != null)
                {
                    AllergyMaster.AllergyName = item.AllergyName != null ? item.AllergyName : AllergyMaster.AllergyName;
                    _context.AllergyMasters.Update(AllergyMaster);
                    await _context.SaveChangesAsync();
                    return AllergyMaster;
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
