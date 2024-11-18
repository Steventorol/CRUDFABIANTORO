using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDFABIANTOROEF.Models;

namespace CRUDFABIANTOROEF.Controllers
{
    public class LibrosAutorsController : Controller
    {
        private readonly CrudfabiantoroContext _context;

        public LibrosAutorsController(CrudfabiantoroContext context)
        {
            _context = context;
        }

        // GET: LibrosAutors
        public async Task<IActionResult> Index()
        {
            var crudfabiantoroContext = _context.LibrosAutors.Include(l => l.IdautorNavigation).Include(l => l.IsbnNavigation);
            return View(await crudfabiantoroContext.ToListAsync());
        }

        // GET: LibrosAutors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librosAutor = await _context.LibrosAutors
                .Include(l => l.IdautorNavigation)
                .Include(l => l.IsbnNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (librosAutor == null)
            {
                return NotFound();
            }

            return View(librosAutor);
        }

        // GET: LibrosAutors/Create
        public IActionResult Create()
        {
            ViewData["Idautor"] = new SelectList(_context.Autors, "Idautor", "Idautor");
            ViewData["Isbn"] = new SelectList(_context.Libros, "Isbn", "Isbn");
            return View();
        }

        // POST: LibrosAutors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Idautor,Isbn")] LibrosAutor librosAutor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(librosAutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idautor"] = new SelectList(_context.Autors, "Idautor", "Idautor", librosAutor.Idautor);
            ViewData["Isbn"] = new SelectList(_context.Libros, "Isbn", "Isbn", librosAutor.Isbn);
            return View(librosAutor);
        }

        // GET: LibrosAutors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librosAutor = await _context.LibrosAutors.FindAsync(id);
            if (librosAutor == null)
            {
                return NotFound();
            }
            ViewData["Idautor"] = new SelectList(_context.Autors, "Idautor", "Idautor", librosAutor.Idautor);
            ViewData["Isbn"] = new SelectList(_context.Libros, "Isbn", "Isbn", librosAutor.Isbn);
            return View(librosAutor);
        }

        // POST: LibrosAutors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Idautor,Isbn")] LibrosAutor librosAutor)
        {
            if (id != librosAutor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(librosAutor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibrosAutorExists(librosAutor.Id))
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
            ViewData["Idautor"] = new SelectList(_context.Autors, "Idautor", "Idautor", librosAutor.Idautor);
            ViewData["Isbn"] = new SelectList(_context.Libros, "Isbn", "Isbn", librosAutor.Isbn);
            return View(librosAutor);
        }

        // GET: LibrosAutors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librosAutor = await _context.LibrosAutors
                .Include(l => l.IdautorNavigation)
                .Include(l => l.IsbnNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (librosAutor == null)
            {
                return NotFound();
            }

            return View(librosAutor);
        }

        // POST: LibrosAutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var librosAutor = await _context.LibrosAutors.FindAsync(id);
            if (librosAutor != null)
            {
                _context.LibrosAutors.Remove(librosAutor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibrosAutorExists(int id)
        {
            return _context.LibrosAutors.Any(e => e.Id == id);
        }
    }
}
