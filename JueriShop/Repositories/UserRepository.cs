using JueriShop.Models;
using JueriShop.Repositories.Interfaces;
using JueriShop.Models.Data;

namespace JueriShop.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext jewelryContext) : base(jewelryContext) { }
    }
    
}
