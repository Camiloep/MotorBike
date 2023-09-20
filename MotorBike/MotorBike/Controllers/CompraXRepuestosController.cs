using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MotorBike.Models;

namespace MotorBike.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CompraXRepuestosController : Controller
    {
        private readonly MotorBikeContext _context;

        public CompraXRepuestosController(MotorBikeContext context)
        {
            _context = context;
        }

        // GET: CompraXRepuestos
        public async Task<IActionResult> Index()
        {
            var motorBikeContext = _context.CompraXRepuestos.Include(c => c.FkCategoriaNavigation).Include(c => c.FkCompraNavigation).Include(c => c.FkRepuestoNavigation);
            return View(await motorBikeContext.ToListAsync());
        }

        // GET: CompraXRepuestos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CompraXRepuestos == null)
            {
                return NotFound();
            }

            var compraXRepuesto = await _context.CompraXRepuestos
                .Include(c => c.FkCategoriaNavigation)
                .Include(c => c.FkCompraNavigation)
                .Include(c => c.FkRepuestoNavigation)
                .FirstOrDefaultAsync(m => m.IdCompraXRepuesto == id);
            if (compraXRepuesto == null)
            {
                return NotFound();
            }

            return View(compraXRepuesto);
        }

        // GET: CompraXRepuestos/Create
        public IActionResult Create()
        {

            ViewData["FkCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "NombreCategoria");
            ViewData["FkCompra"] = new SelectList(_context.Compras, "IdCompra", "IdCompra");
            ViewData["FkRepuesto"] = new SelectList(_context.Repuestos, "IdRepuesto", "NombreRepuesto");
            ViewData["Precio"] = new SelectList(_context.Repuestos, "IdRepuesto", "Precio");



            return View();
        }

        // POST: CompraXRepuestos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompraXRepuesto,FkCompra,FkCategoria,FkRepuesto,Cantidad,PrecioUnitario,Subtotal,PrecioFinal")] CompraXRepuesto compraXRepuesto)
        {
            if (ModelState.IsValid)
            {
                int idRepuestoSeleccionado = compraXRepuesto.FkRepuesto;

                var precio = _context.Repuestos.FirstOrDefault(r => r.IdRepuesto == idRepuestoSeleccionado)?.Precio;

                ViewData["Precio"] = precio;

                _context.Add(compraXRepuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "NombreCategoria", compraXRepuesto.FkCategoria);
            ViewData["FkCompra"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", compraXRepuesto.FkCompra);
            ViewData["FkRepuesto"] = new SelectList(_context.Repuestos, "IdRepuesto", "NombreRepuesto", compraXRepuesto.FkRepuesto);
            
            return View(compraXRepuesto);
        }

        // GET: CompraXRepuestos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CompraXRepuestos == null)
            {
                return NotFound();
            }

            var compraXRepuesto = await _context.CompraXRepuestos.FindAsync(id);
            if (compraXRepuesto == null)
            {
                return NotFound();
            }
            ViewData["FkCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "NombreCategoria", compraXRepuesto.FkCategoria);
            ViewData["FkCompra"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", compraXRepuesto.FkCompra);
            ViewData["FkRepuesto"] = new SelectList(_context.Repuestos, "IdRepuesto", "NombreRepuesto", compraXRepuesto.FkRepuesto);
            return View(compraXRepuesto);
        }

        // POST: CompraXRepuestos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCompraXRepuesto,FkCompra,FkCategoria,FkRepuesto,Cantidad,PrecioUnitario,Subtotal,PrecioFinal")] CompraXRepuesto compraXRepuesto)
        {
            if (id != compraXRepuesto.IdCompraXRepuesto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compraXRepuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraXRepuestoExists(compraXRepuesto.IdCompraXRepuesto))
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
            ViewData["FkCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "NombreCategoria", compraXRepuesto.FkCategoria);
            ViewData["FkCompra"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", compraXRepuesto.FkCompra);
            ViewData["FkRepuesto"] = new SelectList(_context.Repuestos, "IdRepuesto", "NombreRepuesto", compraXRepuesto.FkRepuesto);
            return View(compraXRepuesto);
        }

        // GET: CompraXRepuestos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CompraXRepuestos == null)
            {
                return NotFound();
            }

            var compraXRepuesto = await _context.CompraXRepuestos
                .Include(c => c.FkCategoriaNavigation)
                .Include(c => c.FkRepuestoNavigation)
                .FirstOrDefaultAsync(m => m.IdCompraXRepuesto == id);
            if (compraXRepuesto == null)
            {
                return NotFound();
            }
            else
            {
                _context.CompraXRepuestos.Remove(compraXRepuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }

        //// POST: CompraXRepuestos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.CompraXRepuestos == null)
        //    {
        //        return Problem("Entity set 'MotorBikeContext.CompraXRepuestos'  is null.");
        //    }
        //    var compraXRepuesto = await _context.CompraXRepuestos.FindAsync(id);
        //    if (compraXRepuesto != null)
        //    {
        //        _context.CompraXRepuestos.Remove(compraXRepuesto);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool CompraXRepuestoExists(int id)
        {
          return (_context.CompraXRepuestos?.Any(e => e.IdCompraXRepuesto == id)).GetValueOrDefault();
        }
    }
}
