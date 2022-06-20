using System.Linq.Expressions;
using JueriShop.Repositories.Interfaces;
using JueriShop.Models;
namespace JueriShop.Services
{
    public class UserOrderService:BaseService
    {
        public UserOrderService(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper) { }
        public List<UserOrder> GetUserOrders()
        {
            return wrapper.userOrderRepository.FindAll().ToList();
        }
        public List<UserOrder> GetUserOrderByCondition(Expression<Func<UserOrder, bool>> expression)
        {
            return wrapper.userOrderRepository.FindByCondition(expression).ToList();
        }
        public void AddUserOrder(UserOrder userOrder)
        {
            wrapper.userOrderRepository.Create(userOrder);
        }

        public void UpdateUserOrder(UserOrder userOrder)
        {
            wrapper.userOrderRepository.Update(userOrder);
        }
        public void DeleteUserOrder(UserOrder userOrder)
        {
            wrapper.userOrderRepository.Delete(userOrder);
        }
    }
}
