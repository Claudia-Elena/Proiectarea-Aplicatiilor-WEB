using System.Linq.Expressions;
using JueriShop.Repositories.Interfaces;
using JueriShop.Models;
namespace JueriShop.Services
{
    public class JewelryService : BaseService
    {
        public JewelryService(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper) { }
        public List<Jewelry> GetJewelries()
        {
            return wrapper.jewelryRepository.FindAll().ToList();
        }
        public List<Jewelry> GetJewelryByCondition(Expression<Func<Jewelry, bool>> expression)
        {
            return wrapper.jewelryRepository.FindByCondition(expression).ToList();
        }
        public void AddJewelry(Jewelry jewelry)
        {
            wrapper.jewelryRepository.Create(jewelry);
        }

        public void UpdateJewelry(Jewelry jewelry)
        {
            wrapper.jewelryRepository.Update(jewelry);
        }
        public void DeleteJewelry(Jewelry jewelry)
        {
            wrapper.jewelryRepository.Delete(jewelry);
        }
    }
}
