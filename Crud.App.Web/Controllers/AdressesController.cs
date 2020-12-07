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
    public class AdressesController : Controller
    {
        private readonly Context _context;

        public AdressesController(Context context)
        {
            _context = context;
        }

        // GET: Adresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Adress.ToListAsync());
        }

        // GET: Adresses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adress = await _context.Adress
                .FirstOrDefaultAsync(m => m.ID == id);
            if (adress == null)
            {
                return NotFound();
            }

            return View(adress);
        }

        // GET: Adresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Building,Index,City,Street,Country")] Adress adress)
        {
            if (ModelState.IsValid)
            {
                adress.ID = Guid.NewGuid();
                _context.Add(adress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adress);
        }

        // GET: Adresses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adress = await _context.Adress.FindAsync(id);
            if (adress == null)
            {
                return NotFound();
            }
            return View(adress);
        }

        // POST: Adresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Building,Index,City,Street,Country")] Adress adress)
        {
            if (id != adress.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdressExists(adress.ID))
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
            return View(adress);
        }

        // GET: Adresses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adress = await _context.Adress
                .FirstOrDefaultAsync(m => m.ID == id);
            if (adress == null)
            {
                return NotFound();
            }

            return View(adress);
        }

        // POST: Adresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var adress = await _context.Adress.FindAsync(id);
            _context.Adress.Remove(adress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdressExists(Guid id)
        {
            return _context.Adress.Any(e => e.ID == id);
        }
    }
}
