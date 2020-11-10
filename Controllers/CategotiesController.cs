using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using storeAdmin.Models;

namespace storeAdmin.Controllers
{
    [Authorize]
    public class CategotiesController : Controller
    {
        private readonly CategoriesContext _context;

        public CategotiesController(CategoriesContext context)
        {
            _context = context;
        }

        // GET: Categoties
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: Categoties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoty = await _context.Categories
                .FirstOrDefaultAsync(m => m.id == id);
            if (categoty == null)
            {
                return NotFound();
            }

            return View(categoty);
        }

        // GET: Categoties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categoties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,description,image")] Categoty categoty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoty);
        }

        // GET: Categoties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["catId"] = id;
            if (id == null)
            {
                return NotFound();
            }

            var categoty = await _context.Categories.FindAsync(id);
            if (categoty == null)
            {
                return NotFound();
            }
            return View(categoty);
        }

        // POST: Categoties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,description,image")] Categoty categoty)
        {
            if (id != categoty.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategotyExists(categoty.id))
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
            return View(categoty);
        }

        // GET: Categoties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoty = await _context.Categories
                .FirstOrDefaultAsync(m => m.id == id);
            if (categoty == null)
            {
                return NotFound();
            }

            return View(categoty);
        }

        // POST: Categoties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoty = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(categoty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategotyExists(int id)
        {
            return _context.Categories.Any(e => e.id == id);
        }
    }
}
