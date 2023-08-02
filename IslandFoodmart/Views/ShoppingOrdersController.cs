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
using Microsoft.AspNetCore.Identity;

namespace IslandFoodmart.Views
{
    public class ShoppingOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<DatabaseUser> _userManager;

        public ShoppingOrdersController(ApplicationDbContext context, UserManager<DatabaseUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ShoppingOrders
        [Authorize]
        public async Task<IActionResult> Index()
        {

            var user = await _userManager.GetUserAsync(User);
            if (user.Email == "admin@islandfoodmart.com")
            {
                //If user is admin: Show all orders
                return _context.ShoppingOrder != null ? 
                            View(await _context.ShoppingOrder.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ShoppingOrder'  is null.");
            }
            else
            {
                //Filters and only shows placed by a signed in customer.
                var orders = from r in _context.ShoppingOrder
                             orderby r.UserName
                             where r.UserName == user.UserName
                             select r;
                return View(await orders.OrderByDescending(ShoppingOrder => ShoppingOrder.OrderDate).ToListAsync());
            }
           
            
        }

        // GET: ShoppingOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShoppingOrder == null)
            {
                return NotFound();
            }

            var shoppingOrder = await _context.ShoppingOrder
                .FirstOrDefaultAsync(m => m.ShoppingOrderID == id);
            if (shoppingOrder == null)
            {
                return NotFound();
            }

            return View(shoppingOrder);
        }

        [Authorize]
        // GET: ShoppingOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShoppingOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShoppingOrderID,PickupDate,PriceTotal")] ShoppingOrder shoppingOrder)
        {
            if (!ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                shoppingOrder.OrderDate = DateTime.Now;
                shoppingOrder.UserName = user.UserName;
                shoppingOrder.ShoppingFirstName = user.FirstName;
                var payment = new Payment
                {
                    ShoppingOrder = shoppingOrder,
                    PaymentAmount = shoppingOrder.PriceTotal,
                    PaymentMethod = "Debit",
                    PaymentDate = shoppingOrder.OrderDate

                };
                _context.Add(payment);
                _context.Add(shoppingOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoppingOrder);
        }

        // GET: ShoppingOrders/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShoppingOrder == null)
            {
                return NotFound();
            }

            var shoppingOrder = await _context.ShoppingOrder.FindAsync(id);
            if (shoppingOrder == null)
            {
                return NotFound();
            }
            return View(shoppingOrder);
        }

        // POST: ShoppingOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShoppingOrderID,UserName,OrderDate,PickupDate,PriceTotal")] ShoppingOrder shoppingOrder)
        {
            if (id != shoppingOrder.ShoppingOrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingOrderExists(shoppingOrder.ShoppingOrderID))
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
            return View(shoppingOrder);
        }

        // GET: ShoppingOrders/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShoppingOrder == null)
            {
                return NotFound();
            }

            var shoppingOrder = await _context.ShoppingOrder
                .FirstOrDefaultAsync(m => m.ShoppingOrderID == id);
            if (shoppingOrder == null)
            {
                return NotFound();
            }

            return View(shoppingOrder);
        }

        // POST: ShoppingOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShoppingOrder == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ShoppingOrder'  is null.");
            }
            var shoppingOrder = await _context.ShoppingOrder.FindAsync(id);
            if (shoppingOrder != null)
            {
                _context.ShoppingOrder.Remove(shoppingOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingOrderExists(int id)
        {
          return (_context.ShoppingOrder?.Any(e => e.ShoppingOrderID == id)).GetValueOrDefault();
        }
    }
}
