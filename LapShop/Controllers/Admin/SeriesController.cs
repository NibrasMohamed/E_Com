using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LapShop.DataBaseConnection;
using LapShop.Models;

namespace LapShop.Controllers.Admin
{
    public class SeriesController : Controller
    {
        private readonly MyDbContext _context;

        public SeriesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Series
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Series.Include(s => s.Brand).Include(s => s.Category);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Series/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Series == null)
            {
                return NotFound();
            }

            var series = await _context.Series
                .Include(s => s.Brand)
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.SeriesID == id);
            if (series == null)
            {
                return NotFound();
            }

            return View(series);
        }

        // GET: Series/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandID", "BrandID");
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID");
            return View();
        }

        // POST: Series/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeriesID,SeriesName,CategoryID,BrandId")] Series series)
        {
            if (ModelState.IsValid)
            {
                _context.Add(series);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandID", "BrandID", series.BrandId);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", series.CategoryID);
            return View(series);
        }

        // GET: Series/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Series == null)
            {
                return NotFound();
            }

            var series = await _context.Series.FindAsync(id);
            if (series == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandID", "BrandID", series.BrandId);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", series.CategoryID);
            return View(series);
        }

        // POST: Series/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SeriesID,SeriesName,CategoryID,BrandId")] Series series)
        {
            if (id != series.SeriesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(series);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeriesExists(series.SeriesID))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "BrandID", "BrandID", series.BrandId);
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", series.CategoryID);
            return View(series);
        }

        // GET: Series/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Series == null)
            {
                return NotFound();
            }

            var series = await _context.Series
                .Include(s => s.Brand)
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.SeriesID == id);
            if (series == null)
            {
                return NotFound();
            }

            return View(series);
        }

        // POST: Series/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Series == null)
            {
                return Problem("Entity set 'MyDbContext.Series'  is null.");
            }
            var series = await _context.Series.FindAsync(id);
            if (series != null)
            {
                _context.Series.Remove(series);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeriesExists(int id)
        {
          return (_context.Series?.Any(e => e.SeriesID == id)).GetValueOrDefault();
        }
    }
}
