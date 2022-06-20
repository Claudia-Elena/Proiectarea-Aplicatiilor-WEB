namespace JueriShop.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository categoryRepository { get; }
        IJewelryRepository jewelryRepository { get; }   
        IOrderItemRepository orderItemRepository { get; }
        IOrderStatusRepository  orderStatusRepository { get; }  
        IUserRepository userRepository { get; } 
        IUserOrderRepository userOrderRepository { get; }   
        void Save();
    }
}
