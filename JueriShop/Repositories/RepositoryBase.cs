using JueriShop.Models.Data;
using JueriShop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace JueriShop.Repositories
{

    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext jewelryContext { get; set; }
        public RepositoryBase(ApplicationDbContext jewelryContext)
        {
            this.jewelryContext = jewelryContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.jewelryContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.jewelryContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.jewelryContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            this.jewelryContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.jewelryContext.Set<T>().Remove(entity);
        }
    }


}
