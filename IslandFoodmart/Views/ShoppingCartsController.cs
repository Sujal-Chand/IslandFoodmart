using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IslandFoodmart.Areas.Identity.Data;
using IslandFoodmart.Models;
using Microsoft.AspNetCore.Authorization;

namespace IslandFoodmart.Views
{
    public class ShoppingCartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShoppingCarts
        public async Task<IActionResult> Index()
        {
              return _context.ShoppingCart != null ? 
                          View(await _context.ShoppingCart.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ShoppingCart'  is null.");
        }

        // GET: ShoppingCarts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShoppingCart == null)
            {
                return NotFound();
            }

            var shoppingCart = await _context.ShoppingCart
                .FirstOrDefaultAsync(m => m.ShoppingCartID == id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShoppingCarts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShoppingCartID,Quantity,TotalPrice")] ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppingCart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShoppingCart == null)
            {
                return NotFound();
            }

            var shoppingCart = await _context.ShoppingCart.FindAsync(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }
            return View(shoppingCart);
        }

        // POST: ShoppingCarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShoppingCartID,Quantity,TotalPrice")] ShoppingCart shoppingCart)
        {
            if (id != shoppingCart.ShoppingCartID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingCart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingCartExists(shoppingCart.ShoppingCartID))
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
            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShoppingCart == null)
            {
                return NotFound();
            }

            var shoppingCart = await _context.ShoppingCart
                .FirstOrDefaultAsync(m => m.ShoppingCartID == id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            return View(shoppingCart);
        }

        // POST: ShoppingCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShoppingCart == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ShoppingCart'  is null.");
            }
            var shoppingCart = await _context.ShoppingCart.FindAsync(id);
            if (shoppingCart != null)
            {
                _context.ShoppingCart.Remove(shoppingCart);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingCartExists(int id)
        {
          return (_context.ShoppingCart?.Any(e => e.ShoppingCartID == id)).GetValueOrDefault();
        }
    }
}
