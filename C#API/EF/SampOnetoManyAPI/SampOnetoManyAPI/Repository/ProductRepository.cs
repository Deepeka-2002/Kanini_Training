using SampOnetoManyAPI.Models;

namespace SampOnetoManyAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProCatContext proCatContext;

        public ProductRepository(ProCatContext con)
        {
            proCatContext= con;
        }

        public Product GetProductById(int id)
        {
            return proCatContext.Products.FirstOrDefault(x => x.ProId == id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return proCatContext.Products.ToList();
        }
    }
}
