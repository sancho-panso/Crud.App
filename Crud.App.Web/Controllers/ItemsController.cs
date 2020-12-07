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
    public class ItemsController : Controller
    {
        private readonly Context _context;

        public ItemsController(Context context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var context = _context.Items.Include(i => i.ItemsGroup);
            return View(await context.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.ItemsGroup)
                .FirstOrDefaultAsync(m => m.ItemID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["ItemsGroupID"] = new SelectList(_context.ItemsGroups, "ItemsGroupID", "ItemsGroupCode");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemID,ItemsGroupID,ItemNomNr,ItemName,ItemNameEN,ItemNameRU,ItemQR,Measure,Package,Weight,Type,Pricelist_A,Pricelist_B,Pricelist_C,Pricelist_D,WharehouseQNT,ModifiedDate")] Item item)
        {
            if (ModelState.IsValid)
            {
                item.ItemID = Guid.NewGuid();
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemsGroupID"] = new SelectList(_context.ItemsGroups, "ItemsGroupID", "ItemsGroupCode", item.ItemsGroupID);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["ItemsGroupID"] = new SelectList(_context.ItemsGroups, "ItemsGroupID", "ItemsGroupCode", item.ItemsGroupID);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ItemID,ItemsGroupID,ItemNomNr,ItemName,ItemNameEN,ItemNameRU,ItemQR,Measure,Package,Weight,Type,Pricelist_A,Pricelist_B,Pricelist_C,Pricelist_D,WharehouseQNT,ModifiedDate")] Item item)
        {
            if (id != item.ItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemID))
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
            ViewData["ItemsGroupID"] = new SelectList(_context.ItemsGroups, "ItemsGroupID", "ItemsGroupCode", item.ItemsGroupID);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .Include(i => i.ItemsGroup)
                .FirstOrDefaultAsync(m => m.ItemID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(Guid id)
        {
            return _context.Items.Any(e => e.ItemID == id);
        }
    }
}
