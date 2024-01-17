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
    public class SkıllsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkıllsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Skılls
        public async Task<IActionResult> Index()
        {
              return _context.Skills != null ? 
                          View(await _context.Skills.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Skills'  is null.");
        }

        // GET: Skılls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Skills == null)
            {
                return NotFound();
            }

            var skılls = await _context.Skills
                .FirstOrDefaultAsync(m => m.SkıllsId == id);
            if (skılls == null)
            {
                return NotFound();
            }

            return View(skılls);
        }

        // GET: Skılls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skılls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SkıllsId,Baslık,KısaAcıklama,İsAkısı")] Skılls skılls)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skılls);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skılls);
        }

        // GET: Skılls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Skills == null)
            {
                return NotFound();
            }

            var skılls = await _context.Skills.FindAsync(id);
            if (skılls == null)
            {
                return NotFound();
            }
            return View(skılls);
        }

        // POST: Skılls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SkıllsId,Baslık,KısaAcıklama,İsAkısı")] Skılls skılls)
        {
            if (id != skılls.SkıllsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skılls);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkıllsExists(skılls.SkıllsId))
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
            return View(skılls);
        }

        // GET: Skılls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Skills == null)
            {
                return NotFound();
            }

            var skılls = await _context.Skills
                .FirstOrDefaultAsync(m => m.SkıllsId == id);
            if (skılls == null)
            {
                return NotFound();
            }

            return View(skılls);
        }

        // POST: Skılls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Skills == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Skills'  is null.");
            }
            var skılls = await _context.Skills.FindAsync(id);
            if (skılls != null)
            {
                _context.Skills.Remove(skılls);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkıllsExists(int id)
        {
          return (_context.Skills?.Any(e => e.SkıllsId == id)).GetValueOrDefault();
        }
    }
}
