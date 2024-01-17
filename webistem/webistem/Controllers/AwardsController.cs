using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webistem.Data;
using webistem.Models;

namespace webistem.Controllers
{
    public class AwardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AwardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Awards
        public async Task<IActionResult> Index()
        {
              return _context.Awards != null ? 
                          View(await _context.Awards.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Awards'  is null.");
        }

        // GET: Awards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Awards == null)
            {
                return NotFound();
            }

            var awards = await _context.Awards
                .FirstOrDefaultAsync(m => m.AwardsId == id);
            if (awards == null)
            {
                return NotFound();
            }

            return View(awards);
        }

        // GET: Awards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Awards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AwardsId,Baslık,Acıklama")] Awards awards)
        {
            if (ModelState.IsValid)
            {
                _context.Add(awards);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(awards);
        }

        // GET: Awards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Awards == null)
            {
                return NotFound();
            }

            var awards = await _context.Awards.FindAsync(id);
            if (awards == null)
            {
                return NotFound();
            }
            return View(awards);
        }

        // POST: Awards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AwardsId,Baslık,Acıklama")] Awards awards)
        {
            if (id != awards.AwardsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(awards);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AwardsExists(awards.AwardsId))
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
            return View(awards);
        }

        // GET: Awards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Awards == null)
            {
                return NotFound();
            }

            var awards = await _context.Awards
                .FirstOrDefaultAsync(m => m.AwardsId == id);
            if (awards == null)
            {
                return NotFound();
            }

            return View(awards);
        }

        // POST: Awards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Awards == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Awards'  is null.");
            }
            var awards = await _context.Awards.FindAsync(id);
            if (awards != null)
            {
                _context.Awards.Remove(awards);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AwardsExists(int id)
        {
          return (_context.Awards?.Any(e => e.AwardsId == id)).GetValueOrDefault();
        }
    }
}
