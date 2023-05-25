using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SAP_10.Data;
using SAP_10.Models;

namespace SAP_10.Controllers
{
    public class SotrydniksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SotrydniksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sotrydniks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sotrydnik.ToListAsync());
        }

        // GET: Sotrydniks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sotrydnik = await _context.Sotrydnik
                .FirstOrDefaultAsync(m => m.SotrydnikId == id);
            if (sotrydnik == null)
            {
                return NotFound();
            }

            return View(sotrydnik);
        }

        // GET: Sotrydniks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sotrydniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SotrydnikId,surname,name,patronymic,job_title,subdivision,employment_date")] Sotrydnik sotrydnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sotrydnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sotrydnik);
        }

        // GET: Sotrydniks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sotrydnik = await _context.Sotrydnik.FindAsync(id);
            if (sotrydnik == null)
            {
                return NotFound();
            }
            return View(sotrydnik);
        }

        // POST: Sotrydniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SotrydnikId,surname,name,patronymic,job_title,subdivision,employment_date")] Sotrydnik sotrydnik)
        {
            if (id != sotrydnik.SotrydnikId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sotrydnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SotrydnikExists(sotrydnik.SotrydnikId))
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
            return View(sotrydnik);
        }

        // GET: Sotrydniks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sotrydnik = await _context.Sotrydnik
                .FirstOrDefaultAsync(m => m.SotrydnikId == id);
            if (sotrydnik == null)
            {
                return NotFound();
            }

            return View(sotrydnik);
        }

        // POST: Sotrydniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sotrydnik = await _context.Sotrydnik.FindAsync(id);
            _context.Sotrydnik.Remove(sotrydnik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SotrydnikExists(int id)
        {
            return _context.Sotrydnik.Any(e => e.SotrydnikId == id);
        }
    }
}
