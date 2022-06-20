using System.ComponentModel.DataAnnotations;


namespace JueriShop.Models
{
    public class Category
    {
        [Key]
        public int IdCateg { get; set; }

        public string? Category_Name { get; set; }

        public OrderItem? Jewelry { get; set; }
    }

}
