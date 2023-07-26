using SampOnetoManyAPI.Models;

namespace SampOnetoManyAPI.Repository
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();

        public Product GetProductById(int id);
    }
}
