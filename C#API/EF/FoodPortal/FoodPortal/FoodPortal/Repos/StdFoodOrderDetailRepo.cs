using FoodPortal.Exceptions;
using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FoodPortal.Repos
{
    public class StdFoodOrderDetailRepo : ICrud<StdFoodOrderDetail, IdDTO>
    {
        private readonly FoodPortalContext _context;

        public StdFoodOrderDetailRepo(FoodPortalContext context)
        {
            _context = context;
        }
        public async Task<StdFoodOrderDetail?> Add(StdFoodOrderDetail item)
        {
            try
            {
                var productsIdExists = await _context.StdProducts.AnyAsync(c => c.Id == item.ProductsId);
                if (!productsIdExists)
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
                var newStdFoodOrderDetail = _context.StdFoodOrderDetails.FirstOrDefault(h => h.Id == item.Id);
                if (newStdFoodOrderDetail == null)
                {
                    await _context.StdFoodOrderDetails.AddAsync(item);
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

        public async Task<StdFoodOrderDetail?> Delete(IdDTO item)
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
                var StdFoodOrderDetails = await _context.StdFoodOrderDetails.ToListAsync();
                var myStdFoodOrderDetail = StdFoodOrderDetails.FirstOrDefault(h => h.Id == item.IdInt);
                if (myStdFoodOrderDetail != null)
                {
                    _context.StdFoodOrderDetails.Remove(myStdFoodOrderDetail);
                    await _context.SaveChangesAsync();
                    return myStdFoodOrderDetail;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<StdFoodOrderDetail>?> GetAll()
        {
            try
            {
                var StdFoodOrderDetails = await _context.StdFoodOrderDetails.ToListAsync();
                if (StdFoodOrderDetails != null)
                    return StdFoodOrderDetails;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<StdFoodOrderDetail?> GetValue(IdDTO item)
        {
            try
            {
                var StdFoodOrderDetails = await _context.StdFoodOrderDetails.ToListAsync();
                var StdFoodOrderDetail = StdFoodOrderDetails.SingleOrDefault(h => h.Id == item.IdInt);
                if (StdFoodOrderDetail != null)
                    return StdFoodOrderDetail;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<StdFoodOrderDetail?> Update(StdFoodOrderDetail item)
        {
            try
            {
                var productsIdExists = await _context.StdProducts.AnyAsync(c => c.Id == item.ProductsId);
                if (!productsIdExists)
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
                var StdFoodOrderDetails = await _context.StdFoodOrderDetails.ToListAsync();
                var StdFoodOrderDetail = StdFoodOrderDetails.SingleOrDefault(h => h.Id == item.Id);
                if (StdFoodOrderDetail != null)
                {
                    StdFoodOrderDetail.OrderId = item.OrderId != null ? item.OrderId : StdFoodOrderDetail.OrderId;
                    StdFoodOrderDetail.ProductsId = item.ProductsId != null ? item.ProductsId : StdFoodOrderDetail.ProductsId;

                    _context.StdFoodOrderDetails.Update(StdFoodOrderDetail);
                    await _context.SaveChangesAsync();
                    return StdFoodOrderDetail;
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
