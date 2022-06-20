using System.Linq.Expressions;
using JueriShop.Repositories.Interfaces;
using JueriShop.Models;
namespace JueriShop.Services
{
    public class OrderStatusService:BaseService
    {
        public OrderStatusService(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper) { }
        public List<OrderStatus> GetOrderStatuses()
        {
            return wrapper.orderStatusRepository.FindAll().ToList();
        }
        public List<OrderStatus> GetOrderStatusByCondition(Expression<Func<OrderStatus, bool>> expression)
        {
            return wrapper.orderStatusRepository.FindByCondition(expression).ToList();
        }
        public void AddOrderStatus(OrderStatus orderStatus)
        {
            wrapper.orderStatusRepository.Create(orderStatus);
        }

        public void UpdateOrderStatus(OrderStatus orderStatus)
        {
            wrapper.orderStatusRepository.Update(orderStatus);
        }
        public void DeleteOrderStatus(OrderStatus orderStatus)
        {
            wrapper.orderStatusRepository.Delete(orderStatus);
        }
    }
}
