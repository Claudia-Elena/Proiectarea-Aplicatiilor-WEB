using System.ComponentModel.DataAnnotations;
namespace JueriShop.Models
{
    public class Jewelry
    {
        [Key]
        public int IdJewel { get; set; }
        public int IdCategory { get; set; }
        public ICollection<Category>? Categories { get; set; }
        public string? Name { get; set; }
        public int SerialNumber { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }

        public OrderItem? OrderItem { get; set; }
    }
}
