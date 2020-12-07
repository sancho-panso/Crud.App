using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Crud.App.Data;
using Crud.App.Domains;

namespace Crud.App.Web.Controllers
{
    public class OrderedItemsController : Controller
    {
        private readonly Context _context;

        public OrderedItemsController(Context context)
        {
            _context = context;
        }

        // GET: OrderedItems
        public async Task<IActionResult> Index()
        {
            var context = _context.OrderedItems.Include(o => o.Item).Include(o => o.Order);
            return View(await context.ToListAsync());
        }

        // GET: OrderedItems/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderedItem = await _context.OrderedItems
                .Include(o => o.Item)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (orderedItem == null)
            {
                return NotFound();
            }

            return View(orderedItem);
        }

        // GET: OrderedItems/Create
        public IActionResult Create()
        {
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName");
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "OrderNumber");
            return View();
        }

        // POST: OrderedItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OrderID,ItemID,Ordered_QNT,Price,DiscountID")] OrderedItem orderedItem)
        {
            if (ModelState.IsValid)
            {
                orderedItem.ID = Guid.NewGuid();
                _context.Add(orderedItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName", orderedItem.ItemID);
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "OrderNumber", orderedItem.OrderID);
            return View(orderedItem);
        }

        // GET: OrderedItems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderedItem = await _context.OrderedItems.FindAsync(id);
            if (orderedItem == null)
            {
                return NotFound();
            }
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName", orderedItem.ItemID);
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "OrderNumber", orderedItem.OrderID);
            return View(orderedItem);
        }

        // POST: OrderedItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,OrderID,ItemID,Ordered_QNT,Price,DiscountID")] OrderedItem orderedItem)
        {
            if (id != orderedItem.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderedItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderedItemExists(orderedItem.ID))
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
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName", orderedItem.ItemID);
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "OrderNumber", orderedItem.OrderID);
            return View(orderedItem);
        }

        // GET: OrderedItems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderedItem = await _context.OrderedItems
                .Include(o => o.Item)
                .Include(o => o.Order)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (orderedItem == null)
            {
                return NotFound();
            }

            return View(orderedItem);
        }

        // POST: OrderedItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var orderedItem = await _context.OrderedItems.FindAsync(id);
            _context.OrderedItems.Remove(orderedItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderedItemExists(Guid id)
        {
            return _context.OrderedItems.Any(e => e.ID == id);
        }
    }
}
