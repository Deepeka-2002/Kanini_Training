using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampOnetoManyAPI.Models
{
    public class Product
    {
        [Key]
        public int ProId { get; set; }
        public string ProName { get; set; }
        public int Price { get; set; }


        //Navigation
        public Category category { get; set; }
    }
}
