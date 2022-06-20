using JueriShop.Models;
using JueriShop.Models.Data;
using JueriShop.Repositories.Interfaces;
namespace JueriShop.Repositories
{
    public class JewelryRepository : RepositoryBase<Jewelry>, IJewelryRepository
    {
        public JewelryRepository(ApplicationDbContext jewelryContext) : base(jewelryContext) { }
    }
}
