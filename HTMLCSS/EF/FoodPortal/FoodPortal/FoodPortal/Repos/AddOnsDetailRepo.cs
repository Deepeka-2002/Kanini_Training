using FoodPortal.Exceptions;
using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FoodPortal.Repos
{
    public class AddOnsDetailRepo : ICrud<AddOnsDetail, IdDTO>
    {
        private readonly FoodPortalContext _context;

        public AddOnsDetailRepo(FoodPortalContext context)
        {
            _context = context;
        }
        public async Task<AddOnsDetail?> Add(AddOnsDetail item)
        {
            try
            {

                var addOnsExists = await _context.AddOnsMasters.AnyAsync(c => c.Id == item.AddOnsId);
                if (!addOnsExists)
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
                var newAddOnsDetail = _context.AddOnsDetails.FirstOrDefault(h => h.Id == item.Id);
                if (newAddOnsDetail == null)
                {
                    await _context.AddOnsDetails.AddAsync(item);
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

        public async Task<AddOnsDetail?> Delete(IdDTO item)
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
                var AddOnsDetails = await _context.AddOnsDetails.ToListAsync();
                var myAddOnsDetail = AddOnsDetails.FirstOrDefault(h => h.Id == item.IdInt);
                if (myAddOnsDetail != null)
                {
                    _context.AddOnsDetails.Remove(myAddOnsDetail);
                    await _context.SaveChangesAsync();
                    return myAddOnsDetail;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<AddOnsDetail>?> GetAll()
        {
            try
            {
                var AddOnsDetails = await _context.AddOnsDetails.ToListAsync();
                if (AddOnsDetails != null)
                    return AddOnsDetails;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<AddOnsDetail?> GetValue(IdDTO item)
        {
            try
            {
                var AddOnsDetails = await _context.AddOnsDetails.ToListAsync();
                var AddOnsDetail = AddOnsDetails.SingleOrDefault(h => h.Id == item.IdInt);
                if (AddOnsDetail != null)
                    return AddOnsDetail;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<AddOnsDetail?> Update(AddOnsDetail item)
        {
            try
            {
                var addOnsExists = await _context.AddOnsMasters.AnyAsync(c => c.Id == item.AddOnsId);
                if (!addOnsExists)
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
                var AddOnsDetails = await _context.AddOnsDetails.ToListAsync();
                var AddOnsDetail = AddOnsDetails.SingleOrDefault(h => h.Id == item.Id);
                if (AddOnsDetail != null)
                {
                    AddOnsDetail.AddOnsId = item.AddOnsId != null ? item.AddOnsId : AddOnsDetail.AddOnsId;
                    AddOnsDetail.OrderId = item.OrderId != null ? item.OrderId : AddOnsDetail.OrderId;
                    AddOnsDetail.Quantity = item.Quantity != null ? item.Quantity : AddOnsDetail.Quantity;
                    AddOnsDetail.Cost = item.Cost != null ? item.Cost : AddOnsDetail.Cost;

                    _context.AddOnsDetails.Update(AddOnsDetail);
                    await _context.SaveChangesAsync();
                    return AddOnsDetail;
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
