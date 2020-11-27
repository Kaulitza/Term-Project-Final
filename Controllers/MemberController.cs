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
    public class MemberController : Controller
    {
        private readonly SeekingAllahContext _context;

        public MemberController(SeekingAllahContext context)
        {
            _context = context;
        }

        // GET: Member
        [Authorize(Roles = "Administrator,Manager,User")]
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["CountrySortParm"] = sortOrder == "Country" ? "country_desc" : "Country";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var members = from m in _context.Membership
                          select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                members = members.Where(m => m.name.Contains(searchString)
                || m.email.Contains(searchString)
                || m.email.Contains(searchString)
                || m.City.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    members = members.OrderByDescending(m => m.name);
                    break;
                case "Country":
                    members = members.OrderByDescending(m => m.Country);
                    break;
                default:
                    members = members.OrderBy(m => m.name);
                    break;
            }
            int pageSize = 4;
            return View(await PaginatedList<Members>.CreateAsync(members.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Member/Details/5
        [Authorize(Roles = "Administrator,Manager, User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Membership
                .FirstOrDefaultAsync(m => m.ID == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);
        }

        // GET: Member/Create
        [Authorize(Roles = "Administrator,Manager")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Manager")]

        public async Task<IActionResult> Create([Bind("ID,name,email")] Members members)
        {
            if (ModelState.IsValid)
            {
                _context.Add(members);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(members);
        }

        // GET: Member/Edit/5
        [Authorize(Roles = "Administrator,Manager")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Membership.FindAsync(id);
            if (members == null)
            {
                return NotFound();
            }
            return View(members);
        }

        // POST: Member/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,name,email")] Members members)
        {
            if (id != members.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(members);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembersExists(members.ID))
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
            return View(members);
        }

        // GET: Member/Delete/5
        [Authorize(Roles = "Administrator,Manager")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Membership
                .FirstOrDefaultAsync(m => m.ID == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);
        }

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator,Manager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var members = await _context.Membership.FindAsync(id);
            _context.Membership.Remove(members);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembersExists(int id)
        {
            return _context.Membership.Any(e => e.ID == id);
        }
    }
}
