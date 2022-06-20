
using JueriShop.Models;
using JueriShop.Repositories.Interfaces;
using JueriShop.Models.Data;

namespace JueriShop.Repositories
{
    public class OrderStatusRepository : RepositoryBase<OrderStatus>, IOrderStatusRepository
    {
        public OrderStatusRepository(ApplicationDbContext jewelryContext) : base(jewelryContext) { }
    }

}
