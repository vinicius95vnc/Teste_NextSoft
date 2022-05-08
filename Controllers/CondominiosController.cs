﻿#nullable disable
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
    public class CondominiosController : Controller
    {
        private readonly Context _context;

        public CondominiosController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var total = from AreaTotal in _context.Condominio select AreaTotal;
            var taxa = from IPTU in _context.Condominio select IPTU;


            return View(await _context.Condominio.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condominio = await _context.Condominio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (condominio == null)
            {
                return NotFound();
            }

            return View(condominio);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Bairro, AreaTotal, IPTU")] Condominio condominio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(condominio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(condominio);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condominio = await _context.Condominio.FindAsync(id);
            if (condominio == null)
            {
                return NotFound();
            }
            return View(condominio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Bairro,AreaTotal,IPTU")] Condominio condominio)
        {
            if (id != condominio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(condominio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CondominioExists(condominio.Id))
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
            return View(condominio);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condominio = await _context.Condominio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (condominio == null)
            {
                return NotFound();
            }

            return View(condominio);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var condominio = await _context.Condominio.FindAsync(id);
            _context.Condominio.Remove(condominio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CondominioExists(int id)
        {
            return _context.Condominio.Any(e => e.Id == id);
        }
    }
}
