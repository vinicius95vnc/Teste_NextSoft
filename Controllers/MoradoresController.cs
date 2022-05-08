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
    public class MoradoresController : Controller
    {
        private readonly Context _context;

        public MoradoresController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Morador.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var morador = await _context.Morador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (morador == null)
            {
                return NotFound();
            }

            return View(morador);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Familia,Nome,Idade")] Morador morador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(morador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(morador);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var morador = await _context.Morador.FindAsync(id);
            if (morador == null)
            {
                return NotFound();
            }
            return View(morador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Familia,Nome,Idade")] Morador morador)
        {
            if (id != morador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(morador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoradorExists(morador.Id))
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
            return View(morador);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var morador = await _context.Morador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (morador == null)
            {
                return NotFound();
            }

            return View(morador);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var morador = await _context.Morador.FindAsync(id);
            _context.Morador.Remove(morador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoradorExists(int id)
        {
            return _context.Morador.Any(e => e.Id == id);
        }
    }
}
