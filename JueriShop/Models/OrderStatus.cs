using System.ComponentModel.DataAnnotations;
namespace JueriShop.Models
{
    public class OrderStatus
    {
        [Key]
        public int IdOrdStatus { get; set; }
        public string? Status { get; set; }
        public UserOrder? UserOrder { get; set; }
    }
}
