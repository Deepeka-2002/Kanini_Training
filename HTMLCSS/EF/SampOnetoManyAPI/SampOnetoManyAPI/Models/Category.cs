using System.ComponentModel.DataAnnotations;

namespace SampOnetoManyAPI.Models
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }
        public string? CatName { get; set; }

        //Navigation Property
        public ICollection<Product>? Products { get; set; }
    }
}
