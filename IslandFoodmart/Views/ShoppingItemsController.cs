using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IslandFoodmart.Areas.Identity.Data;
using IslandFoodmart.Models;

namespace IslandFoodmart.Views
{
    public class ShoppingItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoppingItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShoppingItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ShoppingCart.Include(s => s.ShoppingOrder);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ShoppingItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShoppingCart == null)
            {
                return NotFound();
            }

            var shoppingItem = await _context.ShoppingCart
                .Include(s => s.ShoppingOrder)
                .FirstOrDefaultAsync(m => m.ShoppingItemID == id);
            if (shoppingItem == null)
            {
                return NotFound();
            }

            return View(shoppingItem);
        }

        // GET: ShoppingItems/Create
        public IActionResult Create()
        {
            ViewData["ShoppingOrderID"] = new SelectList(_context.ShoppingOrder, "ShoppingOrderID", "ShoppingOrderID");
            return View();
        }

        // POST: ShoppingItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShoppingItemID,ShoppingOrderID,Id,ProductID,Quantity")] ShoppingItem shoppingItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppingItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShoppingOrderID"] = new SelectList(_context.ShoppingOrder, "ShoppingOrderID", "ShoppingOrderID", shoppingItem.ShoppingOrderID);
            return View(shoppingItem);
        }

        // GET: ShoppingItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShoppingCart == null)
            {
                return NotFound();
            }

            var shoppingItem = await _context.ShoppingCart.FindAsync(id);
            if (shoppingItem == null)
            {
                return NotFound();
            }
            ViewData["ShoppingOrderID"] = new SelectList(_context.ShoppingOrder, "ShoppingOrderID", "ShoppingOrderID", shoppingItem.ShoppingOrderID);
            return View(shoppingItem);
        }

        // POST: ShoppingItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShoppingItemID,ShoppingOrderID,Id,ProductID,Quantity")] ShoppingItem shoppingItem)
        {
            if (id != shoppingItem.ShoppingItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingItemExists(shoppingItem.ShoppingItemID))
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
            ViewData["ShoppingOrderID"] = new SelectList(_context.ShoppingOrder, "ShoppingOrderID", "ShoppingOrderID", shoppingItem.ShoppingOrderID);
            return View(shoppingItem);
        }

        // GET: ShoppingItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShoppingCart == null)
            {
                return NotFound();
            }

            var shoppingItem = await _context.ShoppingCart
                .Include(s => s.ShoppingOrder)
                .FirstOrDefaultAsync(m => m.ShoppingItemID == id);
            if (shoppingItem == null)
            {
                return NotFound();
            }

            return View(shoppingItem);
        }

        // POST: ShoppingItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShoppingCart == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ShoppingCart'  is null.");
            }
            var shoppingItem = await _context.ShoppingCart.FindAsync(id);
            if (shoppingItem != null)
            {
                _context.ShoppingCart.Remove(shoppingItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingItemExists(int id)
        {
          return (_context.ShoppingCart?.Any(e => e.ShoppingItemID == id)).GetValueOrDefault();
        }
    }
}
