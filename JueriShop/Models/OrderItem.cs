using System.ComponentModel.DataAnnotations;

namespace JueriShop.Models
{
    public class OrderItem
    {
        [Key]
        public int IdOrdIt { get; set; }

        public int IdJewelry { get; set; }
        public ICollection<Jewelry>? jewelries { get; set; }
        public int UserOrder { get; set; }
        public ICollection<UserOrder>? userOrders { get; set; }


    }
}
