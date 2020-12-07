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
    public class DiscountsController : Controller
    {
        private readonly Context _context;

        public DiscountsController(Context context)
        {
            _context = context;
        }

        // GET: Discounts
        public async Task<IActionResult> Index()
        {
            var context = _context.Discounts.Include(d => d.Client).Include(d => d.ClientGroup).Include(d => d.Item).Include(d => d.ItemGroup);
            return View(await context.ToListAsync());
        }

        // GET: Discounts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discount = await _context.Discounts
                .Include(d => d.Client)
                .Include(d => d.ClientGroup)
                .Include(d => d.Item)
                .Include(d => d.ItemGroup)
                .FirstOrDefaultAsync(m => m.DiscountID == id);
            if (discount == null)
            {
                return NotFound();
            }

            return View(discount);
        }

        // GET: Discounts/Create
        public IActionResult Create()
        {
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "BussinessID");
            ViewData["ClientGroupID"] = new SelectList(_context.ClientsGroups, "ID", "ID");
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName");
            ViewData["ItemGroupID"] = new SelectList(_context.ItemsGroups, "ItemsGroupID", "ItemsGroupCode");
            return View();
        }

        // POST: Discounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiscountID,ClientID,ClientGroupID,ItemGroupID,ItemID,DiscountMultiplier,PricelictCode")] Discount discount)
        {
            if (ModelState.IsValid)
            {
                discount.DiscountID = Guid.NewGuid();
                _context.Add(discount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "BussinessID", discount.ClientID);
            ViewData["ClientGroupID"] = new SelectList(_context.ClientsGroups, "ID", "ID", discount.ClientGroupID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName", discount.ItemID);
            ViewData["ItemGroupID"] = new SelectList(_context.ItemsGroups, "ItemsGroupID", "ItemsGroupCode", discount.ItemGroupID);
            return View(discount);
        }

        // GET: Discounts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discount = await _context.Discounts.FindAsync(id);
            if (discount == null)
            {
                return NotFound();
            }
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "BussinessID", discount.ClientID);
            ViewData["ClientGroupID"] = new SelectList(_context.ClientsGroups, "ID", "ID", discount.ClientGroupID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName", discount.ItemID);
            ViewData["ItemGroupID"] = new SelectList(_context.ItemsGroups, "ItemsGroupID", "ItemsGroupCode", discount.ItemGroupID);
            return View(discount);
        }

        // POST: Discounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DiscountID,ClientID,ClientGroupID,ItemGroupID,ItemID,DiscountMultiplier,PricelictCode")] Discount discount)
        {
            if (id != discount.DiscountID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscountExists(discount.DiscountID))
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
            ViewData["ClientID"] = new SelectList(_context.Clients, "ID", "BussinessID", discount.ClientID);
            ViewData["ClientGroupID"] = new SelectList(_context.ClientsGroups, "ID", "ID", discount.ClientGroupID);
            ViewData["ItemID"] = new SelectList(_context.Items, "ItemID", "ItemName", discount.ItemID);
            ViewData["ItemGroupID"] = new SelectList(_context.ItemsGroups, "ItemsGroupID", "ItemsGroupCode", discount.ItemGroupID);
            return View(discount);
        }

        // GET: Discounts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discount = await _context.Discounts
                .Include(d => d.Client)
                .Include(d => d.ClientGroup)
                .Include(d => d.Item)
                .Include(d => d.ItemGroup)
                .FirstOrDefaultAsync(m => m.DiscountID == id);
            if (discount == null)
            {
                return NotFound();
            }

            return View(discount);
        }

        // POST: Discounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var discount = await _context.Discounts.FindAsync(id);
            _context.Discounts.Remove(discount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscountExists(Guid id)
        {
            return _context.Discounts.Any(e => e.DiscountID == id);
        }
    }
}
