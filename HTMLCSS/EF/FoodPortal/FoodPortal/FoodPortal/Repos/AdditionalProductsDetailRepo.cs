using FoodPortal.Exceptions;
using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FoodPortal.Repos
{
    public class AdditionalProductsDetailRepo : ICrud<AdditionalProductsDetail, IdDTO>
    {
        private readonly FoodPortalContext _context;

    public AdditionalProductsDetailRepo(FoodPortalContext context)
    {
        _context = context;
    }
    public async Task<AdditionalProductsDetail?> Add(AdditionalProductsDetail item)
    {
        try
        {
            var additionalProductExists = await _context.AdditionalProducts.AnyAsync(c => c.Id == item.AdditionalProductsId);
            if (!additionalProductExists)
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
            var newAdditionalProductsDetail = _context.AdditionalProductsDetails.FirstOrDefault(h => h.Id == item.Id);
            if (newAdditionalProductsDetail == null)
            {
                await _context.AdditionalProductsDetails.AddAsync(item);
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

    public async Task<AdditionalProductsDetail?> Delete(IdDTO item)
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
            var AdditionalProductsDetails = await _context.AdditionalProductsDetails.ToListAsync();
            var myAdditionalProductsDetail = AdditionalProductsDetails.FirstOrDefault(h => h.Id == item.IdInt);
            if (myAdditionalProductsDetail != null)
            {
                _context.AdditionalProductsDetails.Remove(myAdditionalProductsDetail);
                await _context.SaveChangesAsync();
                return myAdditionalProductsDetail;
            }
            else
                return null;
        }
        catch (SqlException ex)
        {
            throw new InvalidSqlException(ex.Message);
        }
    }

    public async Task<List<AdditionalProductsDetail>?> GetAll()
    {
        try
        {
            var AdditionalProductsDetails = await _context.AdditionalProductsDetails.ToListAsync();
            if (AdditionalProductsDetails != null)
                return AdditionalProductsDetails;
        }
        catch (SqlException ex)
        {
            throw new InvalidSqlException(ex.Message);
        }
        return null;
    }

    public async Task<AdditionalProductsDetail?> GetValue(IdDTO item)
    {
        try
        {
            var AdditionalProductsDetails = await _context.AdditionalProductsDetails.ToListAsync();
            var AdditionalProductsDetail = AdditionalProductsDetails.SingleOrDefault(h => h.Id == item.IdInt);
            if (AdditionalProductsDetail != null)
                return AdditionalProductsDetail;
        }
        catch (SqlException ex)
        {
            throw new InvalidSqlException(ex.Message);
        }
        return null;
    }

    public async Task<AdditionalProductsDetail?> Update(AdditionalProductsDetail item)
    {
        try
        {
            var additionalProductExists = await _context.AdditionalProducts.AnyAsync(c => c.Id == item.AdditionalProductsId);
            if (!additionalProductExists)
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
            var AdditionalProductsDetails = await _context.AdditionalProductsDetails.ToListAsync();
            var AdditionalProductsDetail = AdditionalProductsDetails.SingleOrDefault(h => h.Id == item.Id);
            if (AdditionalProductsDetail != null)
            {
                AdditionalProductsDetail.AdditionalProductsId = item.AdditionalProductsId != null ? item.AdditionalProductsId : AdditionalProductsDetail.AdditionalProductsId;
                AdditionalProductsDetail.OrderId = item.OrderId != null ? item.OrderId : AdditionalProductsDetail.OrderId;
                AdditionalProductsDetail.Quantity = item.Quantity != null ? item.Quantity : AdditionalProductsDetail.Quantity;
                AdditionalProductsDetail.Cost = item.Cost != null ? item.Cost : AdditionalProductsDetail.Cost;

                _context.AdditionalProductsDetails.Update(AdditionalProductsDetail);
                await _context.SaveChangesAsync();
                return AdditionalProductsDetail;
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
