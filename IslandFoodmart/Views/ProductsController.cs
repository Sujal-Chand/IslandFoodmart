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
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Identity;

namespace IslandFoodmart.Views
{

    public class ProductsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<DatabaseUser> _userManager;



        public ProductsController(ApplicationDbContext context, UserManager<DatabaseUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Products
        public async Task<IActionResult> Index(string SearchString, string sortOrder, string currentFilter, string? savedsearch)
        {
            if (savedsearch != null)
            {
                SearchString = savedsearch;
            }
            ViewBag.SearchURL = SearchString;
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            if (_context.Product == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Product'  is null.");
            }
            if (SearchString != null)
            {

            }
            else
            {
                SearchString = currentFilter;
                ViewBag.SearchURL = SearchString;
            }
            ViewBag.CurrentFilter = SearchString;
            //Includes the fields from Categories (CategoryID and CategoryName).
            var products = from n in _context.Product.Include(p => p.Category)
                           select n;

            //Select from SearchString -- SearchString is also used for finding products of different categories through an or statement.
            if (!String.IsNullOrEmpty(SearchString))
            {
                products = products.Where(ss => ss.ProductName!.Contains(SearchString) || ss.Category.CategoryName!.Contains(SearchString));
            }
            //Switch case function for sort functionality
            switch (sortOrder)
            {
                case "Price":
                    //Highest to lowest price
                    products = products.OrderByDescending(ss => ss.ProductPrice);
                    break;
                case "price_desc":
                    //Lowest to highest price
                    products = products.OrderBy(ss => ss.ProductPrice);
                    break;
                default:
                    //Default case order by product name
                    products = products.OrderBy(ss => ss.ProductName);
                    break;
            }
            return View(await products.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> AddToCart(int? id, string? search)
        {
            var user = await _userManager.GetUserAsync(User);
            var orders = from r in _context.ShoppingOrder
                         orderby r.UserName
                         where r.UserName == user.UserName
                         select r;
            orders = orders.OrderByDescending(s => s.OrderDate);

       
            var first = orders.FirstOrDefault();

            if (first == null)
            {
                var newOrder = new ShoppingOrder
                {
                    OrderDate = DateTime.Now,
                    PickupDate = DateTime.Now,
                    UserName = user.UserName,
                    ShoppingFirstName = user.FirstName,
                    OrderStatus = Status.Incompleted,
                    CartQuantity = 1,
                    PriceTotal = 0
                };
                var payment = new Payment
                {
                    ShoppingOrder = newOrder,
                    PaymentAmount = newOrder.PriceTotal,
                    PaymentMethod = "Debit",
                    PaymentDate = newOrder.OrderDate

                };
                _context.Add(payment);
                _context.Add(newOrder);

                await _context.SaveChangesAsync();

                orders = from r in _context.ShoppingOrder
                         orderby r.UserName
                         where r.UserName == user.UserName
                         select r;

                orders = orders.OrderByDescending(s => s.OrderDate);
                var updatedfirst = orders.FirstOrDefault();
                var newShoppingItem = new ShoppingItem
                {
                    ShoppingOrderID = updatedfirst.ShoppingOrderID,
                    ProductID = (int)id,
                    Quantity = 1
                };
                _context.Add(newShoppingItem);
                await _context.SaveChangesAsync();
                int? ID = (int)id;
                return RedirectToAction("Details", "Products", new { id = ID, inCart = 1, view = search });
            }
            if (first.OrderStatus == Status.Incompleted)
            {
                var ProductFilter = from cr in _context.ShoppingItem.Include(s => s.Product).Include(s => s.ShoppingOrder)
                                    where cr.ShoppingOrderID == first.ShoppingOrderID && cr.ProductID == (int)id
                                    select cr;
                var ThisItem = ProductFilter.FirstOrDefault();
                if (ThisItem == null)
                {
                    var product = await _context.Product.SingleOrDefaultAsync(p => p.ProductID == id);
                    int? Error = 0;
                    if (product.ProductStock > 0)
                    {
                        var newShoppingItem = new ShoppingItem
                        {
                            ShoppingOrderID = first.ShoppingOrderID,
                            ProductID = (int)id,
                            Quantity = 1
                        };
                        product.ProductStock--;
                        first.CartQuantity++;
                        _context.Add(newShoppingItem);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        Error = 1; 
                    }
                    int? ID = (int)id;
                    return RedirectToAction("Details", "Products", new { id = ID, inCart = 1, view = search, error = Error });
                }
                else
                {
                    int? ID = ThisItem.ShoppingItemID; // Replace with the item in your cart
                    int? ShoppingID = ThisItem.ShoppingOrderID;
                    return RedirectToAction("Edit", "ShoppingItems", new { id = ID });
                }
            }
            else
            {
                var newOrder = new ShoppingOrder
                {
                    OrderDate = DateTime.Now,
                    PickupDate = DateTime.Now,
                    UserName = user.UserName,
                    ShoppingFirstName = user.FirstName,
                    OrderStatus = Status.Incompleted,
                    CartQuantity = 1,
                    PriceTotal = 0
                };
                var payment = new Payment
                {
                    ShoppingOrder = newOrder,
                    PaymentAmount = newOrder.PriceTotal,
                    PaymentMethod = "Debit",
                    PaymentDate = newOrder.OrderDate

                };
                _context.Add(payment);
                _context.Add(newOrder);

                await _context.SaveChangesAsync();

                orders = from r in _context.ShoppingOrder
                         orderby r.UserName
                         where r.UserName == user.UserName
                         select r;

                orders = orders.OrderByDescending(s => s.OrderDate);
                var updatedfirst = orders.FirstOrDefault();
                var newShoppingItem = new ShoppingItem
                {
                    ShoppingOrderID = updatedfirst.ShoppingOrderID,
                    ProductID = (int)id,
                    Quantity = 1
                };
                _context.Add(newShoppingItem);
                await _context.SaveChangesAsync();
                int? ID = (int)id;
                return RedirectToAction("Details", "Products", new { id = ID, inCart = 1, view = search});
            }
            
        }
        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id, int? inCart, string? view)
        {
            ViewBag.SearchString = view;
            Console.WriteLine(" This search is {0}", ViewBag.SearchString);
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

           
            var product = await _context.Product
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            if (inCart == 1)
            {
                ViewBag.Message = "Added to cart sucessfully!";
                return View(product);
            }
            else
            {
                return View(product);
            }
           
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("ProductID,CategoryID,ProductName,ImagePath,ProductPrice,ProductStock")] Product product)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,CategoryID,ProductName,ImagePath,ProductPrice,ProductStock")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
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
            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName", product.CategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return (_context.Product?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }
    }
}
