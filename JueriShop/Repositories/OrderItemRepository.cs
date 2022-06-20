using JueriShop.Models;
using JueriShop.Repositories.Interfaces;
using JueriShop.Models.Data;

namespace JueriShop.Repositories
{
    public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationDbContext jewelryContext) : base(jewelryContext) { }
    }
   
}
