using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Term_Project_Version_1.Models;
using Microsoft.AspNetCore.Authorization;

namespace Term_Project_Version_1.Controllers
{
    [Authorize(Roles = "Administrator,Manager")]
    public class PurchaseController : Controller
    {
        private readonly SeekingAllahContext _context;

        public PurchaseController(SeekingAllahContext context)
        {
            _context = context;
        }

        // GET: Purchase
        public async Task<IActionResult> Index()
        {
            var seekingAllahContext = _context.Purchases.Include(p => p.Members);
            return View(await seekingAllahContext.ToListAsync());
        }

        // GET: Purchase/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchases = await _context.Purchases
                .Include(p => p.Members)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (purchases == null)
            {
                return NotFound();
            }

            return View(purchases);
        }

        // GET: Purchase/Create
        public IActionResult Create()
        {
            ViewData["MembersID"] = new SelectList(_context.Membership, "ID", "email");
            return View();
        }

        // POST: Purchase/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Price,MembersID")] Purchases purchases)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchases);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MembersID"] = new SelectList(_context.Membership, "ID", "email", purchases.MembersID);
            return View(purchases);
        }

        // GET: Purchase/Edit/5
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchases = await _context.Purchases.FindAsync(id);
            if (purchases == null)
            {
                return NotFound();
            }
            ViewData["MembersID"] = new SelectList(_context.Membership, "ID", "email", purchases.MembersID);
            return View(purchases);
        }

        // POST: Purchase/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> Edit(string id, [Bind("ID,Price,MembersID")] Purchases purchases)
        {
            if (id != purchases.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchases);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchasesExists(purchases.ID))
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
            ViewData["MembersID"] = new SelectList(_context.Membership, "ID", "email", purchases.MembersID);
            return View(purchases);
        }

        // GET: Purchase/Delete/5
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchases = await _context.Purchases
                .Include(p => p.Members)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (purchases == null)
            {
                return NotFound();
            }

            return View(purchases);
        }

        // POST: Purchase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var purchases = await _context.Purchases.FindAsync(id);
            _context.Purchases.Remove(purchases);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchasesExists(string id)
        {
            return _context.Purchases.Any(e => e.ID == id);
        }
    }
}
