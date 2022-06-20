using JueriShop.Repositories.Interfaces;

using JueriShop.Models.Data;

namespace JueriShop.Repositories
{
public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext? dBContext;
        private IJewelryRepository? _jewelryRepository;
        private IOrderItemRepository? _orderItemRepository;
        private IOrderStatusRepository? _orderStatusRepository;
        private ICategoryRepository? _categoryRepository;
        private IUserOrderRepository? _userOrderRepository;
        private IUserRepository? _userRepository; 
        public IJewelryRepository jewelryRepository
        {
            get
            {
                if (_jewelryRepository == null)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    _jewelryRepository = new JewelryRepository(dBContext);
#pragma warning restore CS8604 // Possible null reference argument.
                }
                return _jewelryRepository;
            }
        }
        public IOrderItemRepository orderItemRepository
        {
            get
            {
                if (_orderItemRepository == null)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    _orderItemRepository = new OrderItemRepository(dBContext);
#pragma warning restore CS8604 // Possible null reference argument.

                }
                return _orderItemRepository;
            }
        }

        public IOrderStatusRepository orderStatusRepository
        {
            get
            {
                if (_orderStatusRepository == null)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    _orderStatusRepository = new OrderStatusRepository(dBContext);
#pragma warning restore CS8604 // Possible null reference argument.
                }
                return _orderStatusRepository;
            }
        }

        public ICategoryRepository categoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    _categoryRepository = new CategoryRepository(dBContext);
#pragma warning restore CS8604 // Possible null reference argument.
                }
                return _categoryRepository;
            }
        }

        public IUserOrderRepository userOrderRepository
        {
            get
            {
                if (_userOrderRepository == null)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    _userOrderRepository = new UserOrderRepository(dBContext);
#pragma warning restore CS8604 // Possible null reference argument.
                }

                return _userOrderRepository;
            }
        }

      

        public IUserRepository userRepository
        {
            get
            {
                if (_userRepository == null)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    _userRepository = new UserRepository(dBContext);
#pragma warning restore CS8604 // Possible null reference argument.
                }
                return _userRepository;
            }
        }

       

        public RepositoryWrapper(ApplicationDbContext jewelryContext)
        {
            dBContext = jewelryContext;
        }
        public void Save()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            dBContext.SaveChanges();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}
