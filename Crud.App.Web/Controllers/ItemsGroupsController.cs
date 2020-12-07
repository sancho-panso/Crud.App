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
    public class ItemsGroupsController : Controller
    {
        private readonly Context _context;

        public ItemsGroupsController(Context context)
        {
            _context = context;
        }

        // GET: ItemsGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemsGroups.ToListAsync());
        }

        // GET: ItemsGroups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemsGroup = await _context.ItemsGroups
                .FirstOrDefaultAsync(m => m.ItemsGroupID == id);
            if (itemsGroup == null)
            {
                return NotFound();
            }

            return View(itemsGroup);
        }

        // GET: ItemsGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemsGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemsGroupID,ItemsGroupCode,ItemsGroupName,ItemsGroupNameEN,ItemsGroupNameRU,ParentItemsGroupCode")] ItemsGroup itemsGroup)
        {
            if (ModelState.IsValid)
            {
                itemsGroup.ItemsGroupID = Guid.NewGuid();
                _context.Add(itemsGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemsGroup);
        }

        // GET: ItemsGroups/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemsGroup = await _context.ItemsGroups.FindAsync(id);
            if (itemsGroup == null)
            {
                return NotFound();
            }
            return View(itemsGroup);
        }

        // POST: ItemsGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ItemsGroupID,ItemsGroupCode,ItemsGroupName,ItemsGroupNameEN,ItemsGroupNameRU,ParentItemsGroupCode")] ItemsGroup itemsGroup)
        {
            if (id != itemsGroup.ItemsGroupID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemsGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemsGroupExists(itemsGroup.ItemsGroupID))
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
            return View(itemsGroup);
        }

        // GET: ItemsGroups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemsGroup = await _context.ItemsGroups
                .FirstOrDefaultAsync(m => m.ItemsGroupID == id);
            if (itemsGroup == null)
            {
                return NotFound();
            }

            return View(itemsGroup);
        }

        // POST: ItemsGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var itemsGroup = await _context.ItemsGroups.FindAsync(id);
            _context.ItemsGroups.Remove(itemsGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemsGroupExists(Guid id)
        {
            return _context.ItemsGroups.Any(e => e.ItemsGroupID == id);
        }
    }
}
