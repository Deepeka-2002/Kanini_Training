using FoodPortal.Exceptions;
using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FoodPortal.Repos
{
    public class OrderRepo : ICrud<Order, IdDTO>
    {
        private readonly FoodPortalContext _context;

        public OrderRepo(FoodPortalContext context)
        {
            _context = context;
        }
        public async Task<Order?> Add(Order item)
        {
            try
            {
                var deliveryOptionExists = await _context.DeliveryOptions.AnyAsync(c => c.Id == item.DeliveryOptionId);
                if (!deliveryOptionExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }
                var plateSizeExists = await _context.PlateSizes.AnyAsync(c => c.Id == item.PlateSizeId);
                if (!plateSizeExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }
                var groupSizeIdExists = await _context.GroupSizes.AnyAsync(c => c.Id == item.GroupSizeId);
                if (!groupSizeIdExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }

                var timeSlotIdExists = await _context.TimeSlots.AnyAsync(c => c.Id == item.TimeSlotId);
                if (!timeSlotIdExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }
                var userNameExists = await _context.Users.AnyAsync(c => c.UserName == item.UserName);
                if (!userNameExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }
                var newOrder = _context.Orders.FirstOrDefault(h => h.Id == item.Id);
                if (newOrder == null)
                {
                    await _context.Orders.AddAsync(item);
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

        public async Task<Order?> Delete(IdDTO item)
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
                var Orders = await _context.Orders.ToListAsync();
                var myOrder = Orders.FirstOrDefault(h => h.Id == item.IdString);
                if (myOrder != null)
                {
                    _context.Orders.Remove(myOrder);
                    await _context.SaveChangesAsync();
                    return myOrder;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<Order>?> GetAll()
        {
            try
            {
                var Orders = await _context.Orders.ToListAsync();
                if (Orders != null)
                    return Orders;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<Order?> GetValue(IdDTO item)
        {
            try
            {
                var Orders = await _context.Orders.ToListAsync();
                var Order = Orders.SingleOrDefault(h => h.Id == item.IdString);
                if (Order != null)
                    return Order;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<Order?> Update(Order item)
        {
            try
            {
                var deliveryOptionExists = await _context.DeliveryOptions.AnyAsync(c => c.Id == item.DeliveryOptionId);
                if (!deliveryOptionExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }
                var plateSizeExists = await _context.PlateSizes.AnyAsync(c => c.Id == item.PlateSizeId);
                if (!plateSizeExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }
                var groupSizeIdExists = await _context.GroupSizes.AnyAsync(c => c.Id == item.GroupSizeId);
                if (!groupSizeIdExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }

                var timeSlotIdExists = await _context.TimeSlots.AnyAsync(c => c.Id == item.TimeSlotId);
                if (!timeSlotIdExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }
                var userNameExists = await _context.Users.AnyAsync(c => c.UserName == item.UserName);
                if (!userNameExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }
                var Orders = await _context.Orders.ToListAsync();
                var Order = Orders.SingleOrDefault(h => h.Id == item.Id);
                if (Order != null)
                {
                    Order.DeliveryOptionId = item.DeliveryOptionId != null ? item.DeliveryOptionId : Order.DeliveryOptionId;
                    Order.PlateSizeId = item.PlateSizeId != null ? item.PlateSizeId : Order.PlateSizeId;
                    Order.AdditionalNote = item.AdditionalNote != null ? item.AdditionalNote : Order.AdditionalNote;
                    Order.Address = item.Address != null ? item.Address : Order.Address;
                    Order.Date = item.Date != null ? item.Date : Order.Date;
                    Order.GroupSizeId = item.GroupSizeId != null ? item.GroupSizeId : Order.GroupSizeId;
                    Order.TimeSlotId = item.TimeSlotId != null ? item.TimeSlotId : Order.TimeSlotId;
                    Order.UserName = item.UserName != null ? item.UserName : Order.UserName;
                    Order.AdditionalAllergy = item.AdditionalAllergy != null ? item.AdditionalAllergy : Order.AdditionalAllergy;


                    _context.Orders.Update(Order);
                    await _context.SaveChangesAsync();
                    return Order;
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
