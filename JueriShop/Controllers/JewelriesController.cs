#nullable disable
using JueriShop.Models;
using JueriShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JueryShopPAW.Controllers
{
    public class JewelriesController : Controller
    {
        private readonly JewelryService _jewelryService;

        public JewelriesController(JewelryService jewelryService)
        {
            _jewelryService = jewelryService;
        }

        // GET: Jewelries
        public IActionResult Index()
        {
            var jewelries = _jewelryService.GetJewelries();
            return View(jewelries);
        }


        // GET: Jewelries/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jewelry = _jewelryService.GetJewelries().FirstOrDefault(m => m.IdJewel == id);
            if (jewelry == null)
            {
                return NotFound();
            }

            return View(jewelry);
        }

        // GET: Jewelries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jewelries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,IdCategory,Name,SerialNumber,Description,Price")] Jewelry jewelry)
        {
            if (ModelState.IsValid)
            {

                _jewelryService.AddJewelry(jewelry);
                _jewelryService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(jewelry);
        }

        // GET: Jewelries/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jewelry = _jewelryService.GetJewelries().FirstOrDefault(m => m.IdJewel == id);
            if (jewelry == null)
            {
                return NotFound();
            }
            return View(jewelry);
        }

        // POST: Jewelries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,IdCategory,Name,SerialNumber,Description,Price")] Jewelry jewelry)
        {
            if (id != jewelry.IdJewel)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _jewelryService.UpdateJewelry(jewelry);
                    _jewelryService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JewelryExists(jewelry.IdJewel))
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
            return View(jewelry);
        }

        // GET: Jewelries/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jewelry = _jewelryService.GetJewelries().FirstOrDefault(m => m.IdJewel == id);
            if (jewelry == null)
            {
                return NotFound();
            }

            return View(jewelry);
        }

        // POST: Jewelries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var jewelry = _jewelryService.GetJewelryByCondition(b => b.IdJewel == id).FirstOrDefault();
            _jewelryService.DeleteJewelry(jewelry);
            _jewelryService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool JewelryExists(int id)
        {
            return _jewelryService.GetJewelries().Any(e => e.IdJewel == id);
        }
    }
}


