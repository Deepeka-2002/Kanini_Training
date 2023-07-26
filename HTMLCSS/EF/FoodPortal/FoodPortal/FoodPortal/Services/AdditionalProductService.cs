using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using FoodPortal.Repos;

namespace FoodPortal.Services
{
    public class AdditionalProductService: IAdditionalProductService
    {
        private readonly ICrud<AdditionalProduct, IdDTO> _additionalProductRepo;
        private readonly ICrud<AdditionalCategoryMaster, IdDTO> _additionalCategoryMasterRepo;


        public AdditionalProductService(ICrud<AdditionalProduct, IdDTO> additionalProductRepo,
            ICrud<AdditionalCategoryMaster, IdDTO> additionalCategoryMasterRepo)
        {
            _additionalProductRepo = additionalProductRepo;
            _additionalCategoryMasterRepo = additionalCategoryMasterRepo;
        }

        public async Task<AdditionalProduct> Add_AdditionalProduct(AdditionalProduct additionalProduct)
        {
            var additionalCategoryMasters = await _additionalCategoryMasterRepo.GetAll();
            AdditionalProduct empty = new AdditionalProduct();

            var additionalcategoryExists = additionalCategoryMasters.Any(c => c.Id == additionalProduct.AdditionalCategoryId);
            if (!additionalcategoryExists)
            {
                // Handle invalid foreign key error
                return empty;
            }
            var AdditionalProducts = await _additionalProductRepo.GetAll();
            var newAdditionalProduct = AdditionalProducts.SingleOrDefault(h => h.Id == additionalProduct.Id);
            if (newAdditionalProduct == null)
            {
                var myAdditionalProduct = await _additionalProductRepo.Add(additionalProduct);
                if (myAdditionalProduct != null)
                    return myAdditionalProduct;
            }
            return empty;
        }

        public async Task<List<AdditionalProduct>?> View_All_AdditionalProducts()
        {
            var AdditionalProducts = await _additionalProductRepo.GetAll();
            /*if (AdditionalProducts != null)*/
                return AdditionalProducts;
           /* return null;*/
        }

        //Get a Particular AdditionalProduct
        public async Task<AdditionalProduct?> View_AdditionalProduct(IdDTO idDTO)
        {
            var AdditionalProduct = await _additionalProductRepo.GetValue(idDTO);
            /*if (AdditionalProduct != null)*/
                return AdditionalProduct;
           /* return null;*/
        }

        //Delete a AdditionalProduct
        public async Task<AdditionalProduct?> Delete_AdditionalProduct(IdDTO idDTO)
        {
            var AdditionalProduct = await _additionalProductRepo.Delete(idDTO);
            /*if (AdditionalProduct != null)*/
                return AdditionalProduct;
            /*return null;*/
        }

        //Update a AdditionalProduct
        public async Task<AdditionalProduct?> Update_AdditionalProduct(AdditionalProduct additionalProduct)
        {
            var additionalCategoryMasters = await _additionalCategoryMasterRepo.GetAll();
            AdditionalProduct empty = new AdditionalProduct();

            var additionalcategoryExists = additionalCategoryMasters.Any(c => c.Id == additionalProduct.AdditionalCategoryId);
            if (!additionalcategoryExists)
            {
                // Handle invalid foreign key error
                return empty;
            }
            var myAdditionalProduct = await _additionalProductRepo.Update(additionalProduct);
            /*if (myAdditionalProduct != null)*/
                return myAdditionalProduct;
           /* return null;*/
        }

        public async Task<List<AdditionalProduct>?> View_by_category_AdditionalProducts(int cat)
        {
            var AdditionalProducts = await _additionalProductRepo.GetAll();
            var AdditionalProductsbycate = AdditionalProducts.Where(a => a.AdditionalCategoryId == cat);
            return AdditionalProductsbycate.ToList();
        }

        public async Task<List<AdditionalProduct>> View_by_foodtype_AdditionalProducts(bool isveg, int cat)
        {
            var AdditionalProducts = await _additionalProductRepo.GetAll();
            var AdditionalProductsbyfoodtype = AdditionalProducts.Where(f => f.IsVeg == isveg && f.AdditionalCategoryId == cat);
            return AdditionalProductsbyfoodtype.ToList();
        }

    }
}
