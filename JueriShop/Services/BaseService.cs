using JueriShop.Repositories.Interfaces;

namespace JueriShop.Services
{
    public class BaseService
    {
        protected IRepositoryWrapper wrapper;
        public BaseService(IRepositoryWrapper repositoryWrapper)
        {
            wrapper = repositoryWrapper;
        }
        public void Save()
        {
            wrapper.Save();
        }
    }
}
