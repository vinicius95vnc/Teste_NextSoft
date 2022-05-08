#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NextSoft.Data;
using NextSoft.Models;

namespace NextSoft.Controllers
{
    public class FamiliasController : Controller
    {
        private readonly Context _context;

        public FamiliasController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Familia.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familia = await _context.Familia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familia == null)
            {
                return NotFound();
            }

            return View(familia);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Id_Condominio,Apto")] Familia familia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(familia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(familia);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familia = await _context.Familia.FindAsync(id);
            if (familia == null)
            {
                return NotFound();
            }
            return View(familia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Id_Condominio,Apto")] Familia familia)
        {
            if (id != familia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(familia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamiliaExists(familia.Id))
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
            return View(familia);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familia = await _context.Familia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familia == null)
            {
                return NotFound();
            }

            return View(familia);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var familia = await _context.Familia.FindAsync(id);
            _context.Familia.Remove(familia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamiliaExists(int id)
        {
            return _context.Familia.Any(e => e.Id == id);
        }
    }
}
