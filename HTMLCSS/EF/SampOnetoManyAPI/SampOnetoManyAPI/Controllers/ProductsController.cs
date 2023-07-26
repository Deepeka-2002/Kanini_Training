using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampOnetoManyAPI.Models;
using SampOnetoManyAPI.Repository;

namespace SampOnetoManyAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       private readonly IProductRepository pro;

        public ProductsController(IProductRepository pro)
        {
            this.pro = pro;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
          return  pro.GetProducts();
        }

        [HttpGet("{id}")]
        public Product Getid(int id)
        {
            return pro.GetProductById(id);
        }
    }
}
