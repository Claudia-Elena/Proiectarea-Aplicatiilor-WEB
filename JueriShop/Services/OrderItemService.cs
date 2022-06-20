using System.Linq.Expressions;
using JueriShop.Repositories.Interfaces;
using JueriShop.Models;
namespace JueriShop.Services
{
    public class OrderItemService:BaseService
    {
        public OrderItemService(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper) { }
        public List<OrderItem> GetOrderItems()
        {
            return wrapper.orderItemRepository.FindAll().ToList();
        }
        public List<OrderItem> GetOrderItemByCondition(Expression<Func<OrderItem, bool>> expression)
        {
            return wrapper.orderItemRepository.FindByCondition(expression).ToList();
        }
        public void AddOrderItem(OrderItem orderItem)
        {
            wrapper.orderItemRepository.Create(orderItem);
        }

        public void UpdateOrderItem(OrderItem orderItem)
        {
            wrapper.orderItemRepository.Update(orderItem);
        }
        public void DeleteOrderItem(OrderItem orderItem)
        {
            wrapper.orderItemRepository.Delete(orderItem);
        }
    }
}
