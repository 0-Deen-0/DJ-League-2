using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DJ_s_League.Models;
using WebApplication1.Data;

namespace DJ_League.Controllers
{
    public class PricePoolsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PricePoolsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PricePools
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PricePool.Include(p => p.Tournament);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PricePools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pricePool = await _context.PricePool
                .Include(p => p.Tournament)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pricePool == null)
            {
                return NotFound();
            }

            return View(pricePool);
        }

        // GET: PricePools/Create
        public IActionResult Create()
        {
            ViewData["TournamentId"] = new SelectList(_context.Set<Tournament>(), "Id", "Id");
            return View();
        }

        // POST: PricePools/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TournamentId,TotalAmount,Currency,PriceForTop10,PriceForTop5,PriceForTop1")] PricePool pricePool)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pricePool);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TournamentId"] = new SelectList(_context.Set<Tournament>(), "Id", "Id", pricePool.TournamentId);
            return View(pricePool);
        }

        // GET: PricePools/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pricePool = await _context.PricePool.FindAsync(id);
            if (pricePool == null)
            {
                return NotFound();
            }
            ViewData["TournamentId"] = new SelectList(_context.Set<Tournament>(), "Id", "Id", pricePool.TournamentId);
            return View(pricePool);
        }

        // POST: PricePools/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TournamentId,TotalAmount,Currency,PriceForTop10,PriceForTop5,PriceForTop1")] PricePool pricePool)
        {
            if (id != pricePool.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pricePool);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PricePoolExists(pricePool.Id))
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
            ViewData["TournamentId"] = new SelectList(_context.Set<Tournament>(), "Id", "Id", pricePool.TournamentId);
            return View(pricePool);
        }

        // GET: PricePools/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pricePool = await _context.PricePool
                .Include(p => p.Tournament)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pricePool == null)
            {
                return NotFound();
            }

            return View(pricePool);
        }

        // POST: PricePools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pricePool = await _context.PricePool.FindAsync(id);
            if (pricePool != null)
            {
                _context.PricePool.Remove(pricePool);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PricePoolExists(int id)
        {
            return _context.PricePool.Any(e => e.Id == id);
        }
    }
}
