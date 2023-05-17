using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GraduaatsProef2022_2023.Data;
using GraduaatsProef2022_2023.Models;

namespace GraduaatsProef2022_2023.Controllers
{
    public class OnderwerpensController : Controller
    {
        private readonly GraduaatsProefDbContext _context;

        public OnderwerpensController(GraduaatsProefDbContext context)
        {
            _context = context;
        }

        // GET: Onderwerpens
        public async Task<IActionResult> Index()
        {
              return _context.Onderwerpen != null ? 
                          View(await _context.Onderwerpen.ToListAsync()) :
                          Problem("Entity set 'GraduaatsProefDbContext.Onderwerpen'  is null.");
        }

        // GET: Onderwerpens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Onderwerpen == null)
            {
                return NotFound();
            }

            var onderwerpen = await _context.Onderwerpen
                .FirstOrDefaultAsync(m => m.OnderwerpId == id);
            if (onderwerpen == null)
            {
                return NotFound();
            }

            return View(onderwerpen);
        }

        // GET: Onderwerpens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Onderwerpens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OnderwerpId,Naam,Omschrijving,Foto,Actie")] Onderwerpen onderwerpen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(onderwerpen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(onderwerpen);
        }

        // GET: Onderwerpens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Onderwerpen == null)
            {
                return NotFound();
            }

            var onderwerpen = await _context.Onderwerpen.FindAsync(id);
            if (onderwerpen == null)
            {
                return NotFound();
            }
            return View(onderwerpen);
        }

        // POST: Onderwerpens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OnderwerpId,Naam,Omschrijving,Foto,Actie")] Onderwerpen onderwerpen)
        {
            if (id != onderwerpen.OnderwerpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(onderwerpen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OnderwerpenExists(onderwerpen.OnderwerpId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Onderwerpens");
            }
            return View(onderwerpen);
        }

        // GET: Onderwerpens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Onderwerpen == null)
            {
                return NotFound();
            }

            var onderwerpen = await _context.Onderwerpen
                .FirstOrDefaultAsync(m => m.OnderwerpId == id);
            if (onderwerpen == null)
            {
                return NotFound();
            }

            return View(onderwerpen);
        }

        // POST: Onderwerpens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Onderwerpen == null)
            {
                return Problem("Entity set 'GraduaatsProefDbContext.Onderwerpen'  is null.");
            }
            var onderwerpen = await _context.Onderwerpen.FindAsync(id);
            if (onderwerpen != null)
            {
                _context.Onderwerpen.Remove(onderwerpen);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OnderwerpenExists(int id)
        {
          return (_context.Onderwerpen?.Any(e => e.OnderwerpId == id)).GetValueOrDefault();
        }
    }
}
