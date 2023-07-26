using FoodPortal.Exceptions;
using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FoodPortal.Repos
{
    public class AllergyDetailRepo : ICrud<AllergyDetail, IdDTO>
    {
        private readonly FoodPortalContext _context;

        public AllergyDetailRepo(FoodPortalContext context)
        {
            _context = context;
        }
        public async Task<AllergyDetail?> Add(AllergyDetail item)
        {
            try
            {
                var ordersIdExists = await _context.Orders.AnyAsync(c => c.Id == item.OrdersId);
                if (!ordersIdExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }

                var allergyIdExists = await _context.AllergyMasters.AnyAsync(c => c.Id == item.AllergyId);
                if (!allergyIdExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }

                var newAllergyDetail = _context.AllergyDetails.FirstOrDefault(h => h.Id == item.Id);
                if (newAllergyDetail == null)
                {
                    await _context.AllergyDetails.AddAsync(item);
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

        public async Task<AllergyDetail?> Delete(IdDTO item)
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
                var AllergyDetails = await _context.AllergyDetails.ToListAsync();
                var myAllergyDetail = AllergyDetails.FirstOrDefault(h => h.Id == item.IdInt);
                if (myAllergyDetail != null)
                {
                    _context.AllergyDetails.Remove(myAllergyDetail);
                    await _context.SaveChangesAsync();
                    return myAllergyDetail;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<AllergyDetail>?> GetAll()
        {
            try
            {
                var AllergyDetails = await _context.AllergyDetails.ToListAsync();
                if (AllergyDetails != null)
                    return AllergyDetails;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<AllergyDetail?> GetValue(IdDTO item)
        {
            try
            {
                var AllergyDetails = await _context.AllergyDetails.ToListAsync();
                var AllergyDetail = AllergyDetails.SingleOrDefault(h => h.Id == item.IdInt);
                if (AllergyDetail != null)
                    return AllergyDetail;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<AllergyDetail?> Update(AllergyDetail item)
        {
            try
            {
                var ordersIdExists = await _context.Orders.AnyAsync(c => c.Id == item.OrdersId);
                if (!ordersIdExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }
                var allergyIdExists = await _context.AllergyMasters.AnyAsync(c => c.Id == item.AllergyId);
                if (!allergyIdExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }
                var AllergyDetails = await _context.AllergyDetails.ToListAsync();
                var AllergyDetail = AllergyDetails.SingleOrDefault(h => h.Id == item.Id);
                if (AllergyDetail != null)
                {
                    AllergyDetail.AllergyId = item.AllergyId != null ? item.AllergyId : AllergyDetail.AllergyId;
                    AllergyDetail.OrdersId = item.OrdersId != null ? item.OrdersId : AllergyDetail.OrdersId;

                    _context.AllergyDetails.Update(AllergyDetail);
                    await _context.SaveChangesAsync();
                    return AllergyDetail;
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
