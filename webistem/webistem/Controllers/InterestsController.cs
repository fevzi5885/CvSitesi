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
    public class InterestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InterestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Interests
        public async Task<IActionResult> Index()
        {
              return _context.Interests != null ? 
                          View(await _context.Interests.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Interests'  is null.");
        }

        // GET: Interests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Interests == null)
            {
                return NotFound();
            }

            var interests = await _context.Interests
                .FirstOrDefaultAsync(m => m.InterestId == id);
            if (interests == null)
            {
                return NotFound();
            }

            return View(interests);
        }

        // GET: Interests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Interests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InterestId,Baslık,Acıklama")] Interests interests)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interests);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interests);
        }

        // GET: Interests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Interests == null)
            {
                return NotFound();
            }

            var interests = await _context.Interests.FindAsync(id);
            if (interests == null)
            {
                return NotFound();
            }
            return View(interests);
        }

        // POST: Interests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InterestId,Baslık,Acıklama")] Interests interests)
        {
            if (id != interests.InterestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interests);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterestsExists(interests.InterestId))
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
            return View(interests);
        }

        // GET: Interests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Interests == null)
            {
                return NotFound();
            }

            var interests = await _context.Interests
                .FirstOrDefaultAsync(m => m.InterestId == id);
            if (interests == null)
            {
                return NotFound();
            }

            return View(interests);
        }

        // POST: Interests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Interests == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Interests'  is null.");
            }
            var interests = await _context.Interests.FindAsync(id);
            if (interests != null)
            {
                _context.Interests.Remove(interests);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterestsExists(int id)
        {
          return (_context.Interests?.Any(e => e.InterestId == id)).GetValueOrDefault();
        }
    }
}
