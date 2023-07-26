using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;

namespace FoodPortal.Services
{
    public class StdProductService: IStdProductService
    {
        private readonly ICrud<StdProduct, IdDTO> _StdProductRepo;

        public StdProductService(ICrud<StdProduct, IdDTO> StdProductRepo)
        {
            _StdProductRepo = StdProductRepo;
        }

        public async Task<StdProduct> Add_StdProduct(StdProduct StdProduct)
        {
            var StdProducts = await _StdProductRepo.GetAll();
            StdProduct empty= new StdProduct();
            var newStdProduct = StdProducts.SingleOrDefault(h => h.Id == StdProduct.Id);
            if (newStdProduct == null)
            {
                var myStdProduct = await _StdProductRepo.Add(StdProduct);
                if (myStdProduct != null)
                    return myStdProduct;
            }
            return empty;
        }

        public async Task<List<StdProduct>?> View_All_StdProducts()
        {
            var StdProducts = await _StdProductRepo.GetAll();
            /*if (StdProducts != null)*/
                return StdProducts;
            /*return null;*/
        }

        //Get a Particular StdProduct
        public async Task<StdProduct?> View_StdProduct(IdDTO idDTO)
        {
            var StdProduct = await _StdProductRepo.GetValue(idDTO);
           /* if (StdProduct != null)*/
                return StdProduct;
           /* return null;*/
        }

        //Delete a StdProduct
        public async Task<StdProduct?> Delete_StdProduct(IdDTO idDTO)
        {
            var StdProduct = await _StdProductRepo.Delete(idDTO);
            /*if (StdProduct != null)*/
                return StdProduct;
           /* return null;*/
        }

        //Update a StdProduct
        public async Task<StdProduct?> Update_StdProduct(StdProduct StdProduct)
        {
            var myStdProduct = await _StdProductRepo.Update(StdProduct);
           /* if (myStdProduct != null)*/
                return myStdProduct;
           /* return null;*/
        }

        public async Task<List<StdProduct>> View_by_category_StdProducts(int cat)
        {
            var StdProducts = await _StdProductRepo.GetAll();
            var stdProductsbycate = StdProducts.Where(c=> c.CategoriesId == cat);
            return stdProductsbycate.ToList();
        }

        public async Task<List<StdProduct>> View_by_foodtype_StdProducts(bool isveg,int cat)
        {
            var StdProducts = await _StdProductRepo.GetAll();
            var Stdproductbyfoodtype = StdProducts.Where(f=> f.IsVeg== isveg && f.CategoriesId == cat);
            return Stdproductbyfoodtype.ToList();
        }

    }
}
