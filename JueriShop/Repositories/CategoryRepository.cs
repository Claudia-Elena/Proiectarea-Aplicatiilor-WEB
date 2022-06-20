using JueriShop.Models;
using JueriShop.Models.Data;
using JueriShop.Repositories.Interfaces;
namespace JueriShop.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext jewelryContext) : base(jewelryContext) { }
    }
}
