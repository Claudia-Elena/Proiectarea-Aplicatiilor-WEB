using System.ComponentModel.DataAnnotations;
namespace JueriShop.Models
{
    public class UserOrder
    {
        [Key]
        public int IdUOrder { get; set; }
        public int UserId { get; set; }
        public ICollection<User>? users { get; set; }
        public string? DeliverAdress { get; set; }
        public string? OrderStatus { get; set; }
        public ICollection<OrderStatus>? orderStatuses { get; set; }
        public int Price { get; set; }

        public OrderItem? OrderItem { get; set; }
    }
}
