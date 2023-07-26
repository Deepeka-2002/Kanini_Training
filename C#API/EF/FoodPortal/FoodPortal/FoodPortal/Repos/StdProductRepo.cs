using FoodPortal.Exceptions;
using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FoodPortal.Repos
{
    public class StdProductRepo : ICrud<StdProduct, IdDTO>
    {
        private readonly FoodPortalContext _context;

        public StdProductRepo(FoodPortalContext context)
        {
            _context = context;
        }
        public async Task<StdProduct?> Add(StdProduct item)
        {
            try
            {
                var categoryExists = await _context.StdFoodCategoryMasters.AnyAsync(c => c.Id == item.CategoriesId);
                if (!categoryExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }

                var newStdProduct = _context.StdProducts.FirstOrDefault(h => h.Id == item.Id);
                if (newStdProduct == null)
                {
                    await _context.StdProducts.AddAsync(item);
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

        public async Task<StdProduct?> Delete(IdDTO item)
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
                var StdProducts = await _context.StdProducts.ToListAsync();
                var myStdProduct = StdProducts.FirstOrDefault(h => h.Id == item.IdInt);
                if (myStdProduct != null)
                {
                    _context.StdProducts.Remove(myStdProduct);
                    await _context.SaveChangesAsync();
                    return myStdProduct;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<StdProduct>?> GetAll()
        {
            try
            {
                var StdProducts = await _context.StdProducts.ToListAsync();
                if (StdProducts != null)
                    return StdProducts;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<StdProduct?> GetValue(IdDTO item)
        {
            try
            {
                var StdProducts = await _context.StdProducts.ToListAsync();
                var StdProduct = StdProducts.SingleOrDefault(h => h.Id == item.IdInt);
                if (StdProduct != null)
                    return StdProduct;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<StdProduct?> Update(StdProduct item)
        {
            try
            {
                var categoryExists = await _context.StdFoodCategoryMasters.AnyAsync(c => c.Id == item.CategoriesId);
                if (!categoryExists)
                {
                    // Handle invalid foreign key error
                    return null;
                }

                var StdProducts = await _context.StdProducts.ToListAsync();
                var StdProduct = StdProducts.SingleOrDefault(h => h.Id == item.Id);
                if (StdProduct != null)
                {
                    StdProduct.CategoriesId = item.CategoriesId != null ? item.CategoriesId : StdProduct.CategoriesId;
                    StdProduct.ProductsName = item.ProductsName != null ? item.ProductsName : StdProduct.ProductsName;
                    StdProduct.IsVeg = item.IsVeg != null ? item.IsVeg : StdProduct.IsVeg;
                    StdProduct.FoodProductImage = item.FoodProductImage != null ? item.FoodProductImage : StdProduct.FoodProductImage;

                    _context.StdProducts.Update(StdProduct);
                    await _context.SaveChangesAsync();
                    return StdProduct;
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
