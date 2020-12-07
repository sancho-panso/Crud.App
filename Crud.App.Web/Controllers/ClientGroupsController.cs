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
    public class ClientGroupsController : Controller
    {
        private readonly Context _context;

        public ClientGroupsController(Context context)
        {
            _context = context;
        }

        // GET: ClientGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClientsGroups.ToListAsync());
        }

        // GET: ClientGroups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientGroup = await _context.ClientsGroups
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clientGroup == null)
            {
                return NotFound();
            }

            return View(clientGroup);
        }

        // GET: ClientGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] ClientGroup clientGroup)
        {
            if (ModelState.IsValid)
            {
                clientGroup.ID = Guid.NewGuid();
                _context.Add(clientGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clientGroup);
        }

        // GET: ClientGroups/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientGroup = await _context.ClientsGroups.FindAsync(id);
            if (clientGroup == null)
            {
                return NotFound();
            }
            return View(clientGroup);
        }

        // POST: ClientGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name")] ClientGroup clientGroup)
        {
            if (id != clientGroup.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientGroupExists(clientGroup.ID))
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
            return View(clientGroup);
        }

        // GET: ClientGroups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientGroup = await _context.ClientsGroups
                .FirstOrDefaultAsync(m => m.ID == id);
            if (clientGroup == null)
            {
                return NotFound();
            }

            return View(clientGroup);
        }

        // POST: ClientGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var clientGroup = await _context.ClientsGroups.FindAsync(id);
            _context.ClientsGroups.Remove(clientGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientGroupExists(Guid id)
        {
            return _context.ClientsGroups.Any(e => e.ID == id);
        }
    }
}
