using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotorBike.Models;

namespace MotorBike.Controllers
{
    [Authorize]
    public class RepuestosController : Controller
    {
        private readonly MotorBikeContext _context;

        public RepuestosController(MotorBikeContext context)
        {
            _context = context;
        }

        // GET: Repuestos
        public async Task<IActionResult> Index()
        {
            var motorBikeContext = _context.Repuestos.Include(r => r.FkCategoriaNavigation);
            return View(await motorBikeContext.ToListAsync());
        }

        // GET: Repuestos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Repuestos == null)
            {
                return NotFound();
            }

            var repuesto = await _context.Repuestos
                .Include(r => r.FkCategoriaNavigation)
                .FirstOrDefaultAsync(m => m.IdRepuesto == id);
            if (repuesto == null)
            {
                return NotFound();
            }

            return View(repuesto);
        }

        // GET: Repuestos/Create
        public IActionResult Create()
        {
            ViewData["FkCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "NombreCategoria");
            return View();
        }

        // POST: Repuestos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRepuesto,FkCategoria,NombreRepuesto,Cantidad,Precio")] Repuesto repuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "NombreCategoria", repuesto.FkCategoria);
            return View(repuesto);
        }

        // GET: Repuestos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Repuestos == null)
            {
                return NotFound();
            }

            var repuesto = await _context.Repuestos.FindAsync(id);
            if (repuesto == null)
            {
                return NotFound();
            }
            ViewData["FkCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "NombreCategoria", repuesto.FkCategoria);
            return View(repuesto);
        }

        // POST: Repuestos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRepuesto,FkCategoria,NombreRepuesto,Cantidad,Precio")] Repuesto repuesto)
        {
            if (id != repuesto.IdRepuesto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepuestoExists(repuesto.IdRepuesto))
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
            ViewData["FkCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "NombreCategoria", repuesto.FkCategoria);
            return View(repuesto);
        }

        [Authorize(Roles = "Admin")]
        // GET: Repuestos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Repuestos == null)
            {
                return NotFound();
            }

            var repuesto = await _context.Repuestos
                .Include(r => r.FkCategoriaNavigation)
                .FirstOrDefaultAsync(m => m.IdRepuesto == id);
            if (repuesto == null)
            {
                return NotFound();
            }
            else
            {
                _context.Repuestos.Remove(repuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

        }

        //// POST: Repuestos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Repuestos == null)
        //    {
        //        return Problem("Entity set 'MotorBikeContext.Repuestos'  is null.");
        //    }
        //    var repuesto = await _context.Repuestos.FindAsync(id);
        //    if (repuesto != null)
        //    {
        //        _context.Repuestos.Remove(repuesto);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool RepuestoExists(int id)
        {
          return (_context.Repuestos?.Any(e => e.IdRepuesto == id)).GetValueOrDefault();
        }
    }
}
