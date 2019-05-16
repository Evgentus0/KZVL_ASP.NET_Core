using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KZVL_Core.Data;
using KZVL_Core.Models;

namespace KZVL_Core.Controllers
{
    public class DivizionsController : Controller
    {
        private readonly KZVLContext _context;

        public DivizionsController(KZVLContext context)
        {
            _context = context;
        }

        // GET: Divizions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Divizions.ToListAsync());
        }

        // GET: Divizions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divizion = await _context.Divizions
                .FirstOrDefaultAsync(m => m.ID == id);
            if (divizion == null)
            {
                return NotFound();
            }

            return View(divizion);
        }

        // GET: Divizions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Divizions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Number")] Divizion divizion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(divizion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(divizion);
        }

        // GET: Divizions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divizion = await _context.Divizions.FindAsync(id);
            if (divizion == null)
            {
                return NotFound();
            }
            return View(divizion);
        }

        // POST: Divizions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Number")] Divizion divizion)
        {
            if (id != divizion.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(divizion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DivizionExists(divizion.ID))
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
            return View(divizion);
        }

        // GET: Divizions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divizion = await _context.Divizions
                .FirstOrDefaultAsync(m => m.ID == id);
            if (divizion == null)
            {
                return NotFound();
            }

            return View(divizion);
        }

        // POST: Divizions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var divizion = await _context.Divizions.FindAsync(id);
            _context.Divizions.Remove(divizion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DivizionExists(int id)
        {
            return _context.Divizions.Any(e => e.ID == id);
        }
    }
}
