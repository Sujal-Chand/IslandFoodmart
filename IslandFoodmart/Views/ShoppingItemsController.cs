using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IslandFoodmart.Areas.Identity.Data;
using IslandFoodmart.Models;
using Microsoft.AspNetCore.Identity;

namespace IslandFoodmart.Views
{
    public class ShoppingItems : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<DatabaseUser> _userManager;

        public ShoppingItems(ApplicationDbContext context, UserManager<DatabaseUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ShoppingItems
        public async Task<IActionResult> Index(int? updatestatus)
        {
            if (updatestatus == 0)
            {
                ViewBag.Status = 0;
            }
            if (updatestatus == 1)
            {
                ViewBag.Status = 1;
            }
            if (updatestatus == 2)
            {
                ViewBag.Status = 2;
            }
            var user = await _userManager.GetUserAsync(User);
            var orders = from r in _context.ShoppingOrder
                         orderby r.UserName
                         where r.UserName == user.UserName
                         select r;
            orders = orders.OrderByDescending(s => s.OrderDate);


            var first = orders.FirstOrDefault();

            var applicationDbContext = from cartitem in _context.ShoppingItem.Include(s => s.Product).Include(s => s.ShoppingOrder)
                                       where cartitem.ShoppingOrderID == first.ShoppingOrderID
                                       select cartitem;

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ShoppingItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShoppingItem == null)
            {
                return NotFound();
            }

            var shoppingItem = await _context.ShoppingItem
                .Include(s => s.Product)
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
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductName");
            ViewData["ShoppingOrderID"] = new SelectList(_context.ShoppingOrder, "ShoppingOrderID", "ShoppingOrderID");
            return View();
        }

        // POST: ShoppingItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShoppingItemID,ShoppingOrderID,ProductID,Quantity")] ShoppingItem shoppingItem)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(shoppingItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductName", shoppingItem.ProductID);
            ViewData["ShoppingOrderID"] = new SelectList(_context.ShoppingOrder, "ShoppingOrderID", "ShoppingOrderID", shoppingItem.ShoppingOrderID);
            return View(shoppingItem);
        }

        // GET: ShoppingItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShoppingItem == null)
            {
                return NotFound();
            }

            var shoppingItem = await _context.ShoppingItem.FindAsync(id);
            if (shoppingItem == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductName", shoppingItem.ProductID);
            ViewData["ShoppingOrderID"] = new SelectList(_context.ShoppingOrder, "ShoppingOrderID", "ShoppingOrderID", shoppingItem.ShoppingOrderID);
            return View(shoppingItem);
        }

        // POST: ShoppingItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShoppingItemID,ShoppingOrderID,ProductID,Quantity")] ShoppingItem shoppingItem)
        {
            if (id != shoppingItem.ShoppingItemID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var orders = from r in _context.ShoppingOrder
                             orderby r.UserName
                             where r.UserName == user.UserName
                             select r;
                orders = orders.OrderByDescending(s => s.OrderDate);
                var first = orders.FirstOrDefault();
                if (shoppingItem.ShoppingOrderID != first.ShoppingOrderID)
                {
                    ModelState.AddModelError( "","Expected Error. This item is from a previous or other users cart.");
                    return View();
                }

                if (shoppingItem.Quantity <= 0)
                {
                    return RedirectToAction("Index", "ShoppingItems", new { updatestatus = 2 });
                }

                try
                {
                    var pastitem = from r in _context.ShoppingItem.AsNoTracking()
                                   orderby r.ShoppingOrderID
                                   where r.ShoppingOrderID == first.ShoppingOrderID && r.ProductID == shoppingItem.ProductID
                                   select r;
                    var products = from p in _context.Product.AsNoTracking()
                                   where p.ProductID == shoppingItem.ProductID
                                  select p;
                    var savedproduct = await _context.Product.SingleOrDefaultAsync(p => p.ProductID == shoppingItem.ProductID);
                    var thisproduct = products.FirstOrDefault();
                    var pastquantity = pastitem.FirstOrDefault();
                    int quantity = thisproduct.ProductStock;
                    quantity += pastquantity.Quantity;
                    quantity -= shoppingItem.Quantity;
                    int testquantity = quantity;
                    if (testquantity >= 0)
                    {
                        savedproduct.ProductStock = quantity;
                        _context.Update(shoppingItem);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        return RedirectToAction("Index", "ShoppingItems", new { updatestatus = 0});
                    }
                  
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
                return RedirectToAction("Index", "ShoppingItems", new { updatestatus = 1 });
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductName", shoppingItem.ProductID);
            ViewData["ShoppingOrderID"] = new SelectList(_context.ShoppingOrder, "ShoppingOrderID", "ShoppingOrderID", shoppingItem.ShoppingOrderID);
            return View(shoppingItem);
        }

        // GET: ShoppingItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShoppingItem == null)
            {
                return NotFound();
            }

            var shoppingItem = await _context.ShoppingItem
                .Include(s => s.Product)
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
            if (_context.ShoppingItem == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ShoppingItem'  is null.");
            }
            var shoppingItem = await _context.ShoppingItem.FindAsync(id);
            if (shoppingItem != null)
            {
                int quantity = shoppingItem.Quantity;
                var savedproduct = await _context.Product.SingleOrDefaultAsync(p => p.ProductID == shoppingItem.ProductID);
                savedproduct.ProductStock += quantity;
                _context.ShoppingItem.Remove(shoppingItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingItemExists(int id)
        {
          return (_context.ShoppingItem?.Any(e => e.ShoppingItemID == id)).GetValueOrDefault();
        }
    }
}
