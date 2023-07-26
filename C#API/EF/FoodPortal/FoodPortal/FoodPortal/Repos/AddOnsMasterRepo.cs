using FoodPortal.Exceptions;
using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FoodPortal.Repos
{
    public class AddOnsMasterRepo : ICrud<AddOnsMaster, IdDTO>
    {
        private readonly FoodPortalContext _context;

        public AddOnsMasterRepo(FoodPortalContext context)
        {
            _context = context;
        }
        public async Task<AddOnsMaster?> Add(AddOnsMaster item)
        {
            try
            {
                var newAddOnsMaster = _context.AddOnsMasters.SingleOrDefault(h => h.Id == item.Id);
                if (newAddOnsMaster == null)
                {
                    await _context.AddOnsMasters.AddAsync(item);
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

        public async Task<AddOnsMaster?> Delete(IdDTO item)
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
                var addOnsMasters = await _context.AddOnsMasters.ToListAsync();
                var myAddOnsMaster = addOnsMasters.FirstOrDefault(h => h.Id == item.IdInt);
                if (myAddOnsMaster != null)
                {
                    _context.AddOnsMasters.Remove(myAddOnsMaster);
                    await _context.SaveChangesAsync();
                    return myAddOnsMaster;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<AddOnsMaster>?> GetAll()
        {
            try
            {
                var AddOnsMasters = await _context.AddOnsMasters.ToListAsync();
                if (AddOnsMasters != null)
                    return AddOnsMasters;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<AddOnsMaster?> GetValue(IdDTO item)
        {
            try
            {
                var AddOnsMasters = await _context.AddOnsMasters.ToListAsync();
                var AddOnsMaster = AddOnsMasters.SingleOrDefault(h => h.Id == item.IdInt);
                if (AddOnsMaster != null)
                    return AddOnsMaster;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<AddOnsMaster?> Update(AddOnsMaster item)
        {
            try
            {
                var existingAddOnsMaster = await _context.AddOnsMasters.FindAsync(item.Id);
                if (existingAddOnsMaster == null)
                {
                    return null;
                }

                existingAddOnsMaster.AddOnsName = item.AddOnsName != null ? item.AddOnsName : existingAddOnsMaster.AddOnsName;
                existingAddOnsMaster.UnitPrice = item.UnitPrice != null ? item.UnitPrice : existingAddOnsMaster.UnitPrice;
                existingAddOnsMaster.AddOnsImage = item.AddOnsImage != null ? item.AddOnsImage : existingAddOnsMaster.AddOnsImage;
                _context.AddOnsMasters.Update(existingAddOnsMaster);
                await _context.SaveChangesAsync();
                return existingAddOnsMaster;

            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            
        }
    }
}
