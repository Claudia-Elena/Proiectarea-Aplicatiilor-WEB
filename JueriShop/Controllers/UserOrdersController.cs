#nullable disable
using JueriShop.Models;
using JueriShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JueryShopPAW.Controllers
{
    public class UserOrdersController : Controller
    {
        private readonly UserOrderService _userOrderService;

        public UserOrdersController(UserOrderService userOrderService)
        {
            _userOrderService = userOrderService;
        }

        // GET: UserOrders
        public IActionResult Index()
        {
            var usersOrder = _userOrderService.GetUserOrders();
            return View(usersOrder);
        }

        // GET: UserOrders/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOrder = _userOrderService.GetUserOrders().FirstOrDefault(m => m.IdUOrder == id);
            if (userOrder == null)
            {
                return NotFound();
            }

            return View(userOrder);
        }

        // GET: UserOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,UserId,DeliverAdress,OrderStatus,Price")] UserOrder userOrder)
        {
            if (ModelState.IsValid)
            {
                _userOrderService.AddUserOrder(userOrder);
                _userOrderService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(userOrder);
        }

        // GET: UserOrders/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOrder = _userOrderService.GetUserOrders().FirstOrDefault(m => m.IdUOrder == id);

            if (userOrder == null)
            {
                return NotFound();
            }
            return View(userOrder);
        }

        // POST: UserOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,UserId,DeliverAdress,OrderStatus,Price")] UserOrder userOrder)
        {
            if (id != userOrder.IdUOrder)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _userOrderService.UpdateUserOrder(userOrder);
                    _userOrderService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserOrderExists(userOrder.IdUOrder))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userOrder);
        }

        // GET: UserOrders/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userOrder = _userOrderService.GetUserOrders().FirstOrDefault(m => m.IdUOrder == id);
            if (userOrder == null)
            {
                return NotFound();
            }

            return View(userOrder);
        }

        // POST: UserOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var userOrder = _userOrderService.GetUserOrderByCondition(b => b.IdUOrder == id).FirstOrDefault();
            _userOrderService.DeleteUserOrder(userOrder);
            _userOrderService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool UserOrderExists(int id)
        {
            return _userOrderService.GetUserOrders().Any(e => e.IdUOrder == id);
        }
    }
}
