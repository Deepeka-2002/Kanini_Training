using FoodPortal.Exceptions;
using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FoodPortal.Repos
{
    public class PlateSizeRepo : ICrud<PlateSize, IdDTO>
    {
        private readonly FoodPortalContext _context;

        public PlateSizeRepo(FoodPortalContext context)
        {
            _context = context;
        }
        public async Task<PlateSize?> Add(PlateSize item)
        {
            try
            {
                var newPlateSize = _context.PlateSizes.SingleOrDefault(h => h.Id == item.Id);
                if (newPlateSize == null)
                {

                    await _context.PlateSizes.AddAsync(item);
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

        public async Task<PlateSize?> Delete(IdDTO item)
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
                var PlateSizes = await _context.PlateSizes.ToListAsync();
                var myPlateSize = PlateSizes.FirstOrDefault(h => h.Id == item.IdInt);
                if (myPlateSize != null)
                {
                    _context.PlateSizes.Remove(myPlateSize);
                    await _context.SaveChangesAsync();
                    return myPlateSize;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<PlateSize>?> GetAll()
        {
            try
            {
                var PlateSizes = await _context.PlateSizes.ToListAsync();
                if (PlateSizes != null)
                    return PlateSizes;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<PlateSize?> GetValue(IdDTO item)
        {
            try
            {
                var PlateSizes = await _context.PlateSizes.ToListAsync();
                var PlateSize = PlateSizes.SingleOrDefault(h => h.Id == item.IdInt);
                if (PlateSize != null)
                    return PlateSize;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<PlateSize?> Update(PlateSize item)
        {
            try
            {
                var PlateSizes = await _context.PlateSizes.ToListAsync();
                var PlateSize = PlateSizes.SingleOrDefault(h => h.Id == item.Id);
                if (PlateSize != null)
                {
                    PlateSize.PlateType = item.PlateType != null ? item.PlateType : PlateSize.PlateType;
                    PlateSize.VegPlateCost = item.VegPlateCost != null ? item.VegPlateCost : PlateSize.VegPlateCost;
                    PlateSize.NonvegPlateCost = item.NonvegPlateCost != null ? item.NonvegPlateCost : PlateSize.NonvegPlateCost;

                    _context.PlateSizes.Update(PlateSize);
                    await _context.SaveChangesAsync();
                    return PlateSize;
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
