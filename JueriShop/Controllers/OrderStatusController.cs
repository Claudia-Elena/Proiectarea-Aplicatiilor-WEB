#nullable disable
using JueriShop.Models;
using JueriShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JueryShopPAW.Controllers
{
    public class OrderStatusController : Controller
    {
        private readonly OrderStatusService _orderStatusService;

        public OrderStatusController(OrderStatusService orderStatus)
        {
            _orderStatusService = orderStatus;
        }

        // GET: OrderStatus
        public IActionResult Index()
        {
            var orderStatus = _orderStatusService.GetOrderStatuses();
            return View(orderStatus);
        }

        // GET: OrderStatus/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderStatus = _orderStatusService.GetOrderStatuses().FirstOrDefault(m => m.IdOrdStatus == id);

            if (orderStatus == null)
            {
                return NotFound();
            }

            return View(orderStatus);
        }

        // GET: OrderStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Status")] OrderStatus orderStatus)
        {
            if (ModelState.IsValid)
            {
                _orderStatusService.AddOrderStatus(orderStatus);
                _orderStatusService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(orderStatus);
        }

        // GET: OrderStatus/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderStatus = _orderStatusService.GetOrderStatuses().FirstOrDefault(m => m.IdOrdStatus == id);
            if (orderStatus == null)
            {
                return NotFound();
            }
            return View(orderStatus);
        }

        // POST: OrderStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Status")] OrderStatus orderStatus)
        {
            if (id != orderStatus.IdOrdStatus)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _orderStatusService.UpdateOrderStatus(orderStatus);
                    _orderStatusService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderStatusExists(orderStatus.IdOrdStatus))
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
            return View(orderStatus);
        }

        // GET: OrderStatus/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderStatus = _orderStatusService.GetOrderStatuses().FirstOrDefault(m => m.IdOrdStatus == id);
            if (orderStatus == null)
            {
                return NotFound();
            }

            return View(orderStatus);
        }

        // POST: OrderStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var orderStatus = _orderStatusService.GetOrderStatusByCondition(b => b.IdOrdStatus == id).FirstOrDefault();
            _orderStatusService.DeleteOrderStatus(orderStatus);
            _orderStatusService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderStatusExists(int id)
        {
            return _orderStatusService.GetOrderStatuses().Any(e => e.IdOrdStatus == id);
        }
    }
}
