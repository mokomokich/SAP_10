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
    public class DocumentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Document.Include(d => d.Sotrydnik).Include(d => d.Vacation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Document
                .Include(d => d.Sotrydnik)
                .Include(d => d.Vacation)
                .FirstOrDefaultAsync(m => m.DocumentId == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // GET: Documents/Create
        public IActionResult Create()
        {
            ViewData["F_Code_Sotrydnik"] = new SelectList(_context.Sotrydnik, "SotrydnikId", "SotrydnikId");
            ViewData["F_Code_Vacation"] = new SelectList(_context.Vacation, "VacationId", "VacationId");
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentId,code_document,registration_date,holiday_start_date,holiday_end_date,F_Code_Vacation,F_Code_Sotrydnik")] Document document)
        {
            if (ModelState.IsValid)
            {
                _context.Add(document);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["F_Code_Sotrydnik"] = new SelectList(_context.Sotrydnik, "SotrydnikId", "SotrydnikId", document.F_Code_Sotrydnik);
            ViewData["F_Code_Vacation"] = new SelectList(_context.Vacation, "VacationId", "VacationId", document.F_Code_Vacation);
            return View(document);
        }

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Document.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }
            ViewData["F_Code_Sotrydnik"] = new SelectList(_context.Sotrydnik, "SotrydnikId", "SotrydnikId", document.F_Code_Sotrydnik);
            ViewData["F_Code_Vacation"] = new SelectList(_context.Vacation, "VacationId", "VacationId", document.F_Code_Vacation);
            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocumentId,code_document,registration_date,holiday_start_date,holiday_end_date,F_Code_Vacation,F_Code_Sotrydnik")] Document document)
        {
            if (id != document.DocumentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(document);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentExists(document.DocumentId))
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
            ViewData["F_Code_Sotrydnik"] = new SelectList(_context.Sotrydnik, "SotrydnikId", "SotrydnikId", document.F_Code_Sotrydnik);
            ViewData["F_Code_Vacation"] = new SelectList(_context.Vacation, "VacationId", "VacationId", document.F_Code_Vacation);
            return View(document);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Document
                .Include(d => d.Sotrydnik)
                .Include(d => d.Vacation)
                .FirstOrDefaultAsync(m => m.DocumentId == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var document = await _context.Document.FindAsync(id);
            _context.Document.Remove(document);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentExists(int id)
        {
            return _context.Document.Any(e => e.DocumentId == id);
        }
    }
}
