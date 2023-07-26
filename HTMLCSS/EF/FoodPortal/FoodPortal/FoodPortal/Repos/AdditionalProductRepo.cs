using FoodPortal.Exceptions;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using Microsoft.Data.SqlClient;
using FoodPortal.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodPortal.Repos
{
    public class AdditionalProductRepo: ICrud<AdditionalProduct, IdDTO>
    {
        private readonly FoodPortalContext _context;

        public AdditionalProductRepo(FoodPortalContext context)
        {
            _context = context;
        }
        public async Task<AdditionalProduct?> Add(AdditionalProduct item)
        {
            try
            {
                var additionalcategoryExists = await _context.AdditionalCategoryMasters.
    AnyAsync(c => c.Id == item.AdditionalCategoryId);
                if (!additionalcategoryExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }
                var newAdditionalProduct = _context.AdditionalCategoryMasters.FirstOrDefault(h => h.Id == item.Id);
                if (newAdditionalProduct == null)
                {
                    await _context.AdditionalProducts.AddAsync(item);
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

        public async Task<AdditionalProduct?> Delete(IdDTO item)
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
                var AdditionalProducts = await _context.AdditionalProducts.ToListAsync();
                var myAdditionalProduct = AdditionalProducts.FirstOrDefault(h => h.Id == item.IdInt);
                if (myAdditionalProduct != null)
                {
                    _context.AdditionalProducts.Remove(myAdditionalProduct);
                    await _context.SaveChangesAsync();
                    return myAdditionalProduct;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<AdditionalProduct>?> GetAll()
        {
            try
            {
                var AdditionalProducts = await _context.AdditionalProducts.ToListAsync();
                if (AdditionalProducts != null)
                    return AdditionalProducts;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<AdditionalProduct?> GetValue(IdDTO item)
        {
            try
            {
                var AdditionalProducts = await _context.AdditionalProducts.ToListAsync();
                var AdditionalProduct = AdditionalProducts.SingleOrDefault(h => h.Id == item.IdInt);
                if (AdditionalProduct != null)
                    return AdditionalProduct;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<AdditionalProduct?> Update(AdditionalProduct item)
        {
            try
            {
                var existingAdditionalProduct = await _context.AdditionalProducts.FindAsync(item.Id);
                if (existingAdditionalProduct == null)
                {
                    return null;
                }
                var additionalcategoryExists = await _context.AdditionalCategoryMasters
                    .AnyAsync(c => c.Id == item.AdditionalCategoryId);
                if (!additionalcategoryExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }

                existingAdditionalProduct.AdditionalCategoryId = item.AdditionalCategoryId != null ? item.AdditionalCategoryId : existingAdditionalProduct.AdditionalCategoryId;
                existingAdditionalProduct.AdditionalProductsName = item.AdditionalProductsName != null ? item.AdditionalProductsName : existingAdditionalProduct.AdditionalProductsName;
                existingAdditionalProduct.IsVeg = item.IsVeg != null ? item.IsVeg : existingAdditionalProduct.IsVeg;
                existingAdditionalProduct.UnitPrice = item.UnitPrice != null ? item.UnitPrice : existingAdditionalProduct.UnitPrice;
                existingAdditionalProduct.AdditionalProductsImages = item.AdditionalProductsImages != null ? item.AdditionalProductsImages : existingAdditionalProduct.AdditionalProductsImages;

                await _context.SaveChangesAsync();
                return existingAdditionalProduct;

            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }
    }
}
