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
    public class ClientsController : Controller
    {
        private readonly Context _context;

        public ClientsController(Context context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var context = _context.Clients.Include(c => c.Adress).Include(c => c.DeliveryAdress).Include(c => c.Group);
            return View(await context.ToListAsync());
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.Adress)
                .Include(c => c.DeliveryAdress)
                .Include(c => c.Group)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            ViewData["AdressID"] = new SelectList(_context.Set<Adress>(), "ID", "City");
            ViewData["DeliveryAdressID"] = new SelectList(_context.Set<Adress>(), "ID", "City");
            ViewData["ClientsGroupID"] = new SelectList(_context.ClientsGroups, "ID", "ID");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,BussinessID,VAT_ID,Phone,Email,AdressID,DeliveryAdressID,CreditLimit,PricelistCode,ClientsGroupID")] Client client)
        {
            if (ModelState.IsValid)
            {
                client.ID = Guid.NewGuid();
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdressID"] = new SelectList(_context.Set<Adress>(), "ID", "City", client.AdressID);
            ViewData["DeliveryAdressID"] = new SelectList(_context.Set<Adress>(), "ID", "City", client.DeliveryAdressID);
            ViewData["ClientsGroupID"] = new SelectList(_context.ClientsGroups, "ID", "ID", client.ClientsGroupID);
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            ViewData["AdressID"] = new SelectList(_context.Set<Adress>(), "ID", "City", client.AdressID);
            ViewData["DeliveryAdressID"] = new SelectList(_context.Set<Adress>(), "ID", "City", client.DeliveryAdressID);
            ViewData["ClientsGroupID"] = new SelectList(_context.ClientsGroups, "ID", "ID", client.ClientsGroupID);
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,Name,BussinessID,VAT_ID,Phone,Email,AdressID,DeliveryAdressID,CreditLimit,PricelistCode,ClientsGroupID")] Client client)
        {
            if (id != client.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ID))
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
            ViewData["AdressID"] = new SelectList(_context.Set<Adress>(), "ID", "City", client.AdressID);
            ViewData["DeliveryAdressID"] = new SelectList(_context.Set<Adress>(), "ID", "City", client.DeliveryAdressID);
            ViewData["ClientsGroupID"] = new SelectList(_context.ClientsGroups, "ID", "ID", client.ClientsGroupID);
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.Adress)
                .Include(c => c.DeliveryAdress)
                .Include(c => c.Group)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var client = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(Guid id)
        {
            return _context.Clients.Any(e => e.ID == id);
        }
    }
}
