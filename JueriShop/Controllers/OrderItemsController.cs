#nullable disable
using JueriShop.Models;
using JueriShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JueryShopPAW.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly OrderItemService _orderItemService;

        public OrderItemsController(OrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        // GET: OrderItems
        public IActionResult Index()
        {
            var orderItem = _orderItemService.GetOrderItems();
            return View(orderItem);
        }


        // GET: OrderItems/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItem = _orderItemService.GetOrderItems().FirstOrDefault(m => m.IdOrdIt == id);

            if (orderItem == null)
            {
                return NotFound();
            }

            return View(orderItem);
        }

        // GET: OrderItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,IdJewelry,UserOrder")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {

                _orderItemService.AddOrderItem(orderItem);
                _orderItemService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(orderItem);
        }

        // GET: OrderItems/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var orderItem = _orderItemService.GetOrderItems().FirstOrDefault(m => m.IdOrdIt == id);
            if (orderItem == null)
            {
                return NotFound();
            }
            return View(orderItem);
        }

        // POST: OrderItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,IdJewelry,UserOrder")] OrderItem orderItem)
        {
            if (id != orderItem.IdOrdIt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _orderItemService.UpdateOrderItem(orderItem);
                    _orderItemService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderItemExists(orderItem.IdOrdIt))
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
            return View(orderItem);
        }

        // GET: OrderItems/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItem = _orderItemService.GetOrderItems().FirstOrDefault(m => m.IdOrdIt == id);
            if (orderItem == null)
            {
                return NotFound();
            }

            return View(orderItem);
        }

        // POST: OrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var orderItem = _orderItemService.GetOrderItemByCondition(b => b.IdOrdIt == id).FirstOrDefault();
            _orderItemService.DeleteOrderItem(orderItem);
            _orderItemService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderItemExists(int id)
        {
            return _orderItemService.GetOrderItems().Any(e => e.IdOrdIt == id);
        }
    }
}
