
using JueriShop.Models;
using JueriShop.Repositories.Interfaces;
using JueriShop.Models.Data;

namespace JueriShop.Repositories
{
    public class UserOrderRepository : RepositoryBase<UserOrder>, IUserOrderRepository
    {
        public UserOrderRepository(ApplicationDbContext jewelryContext) : base(jewelryContext) { }
    }
    
}
