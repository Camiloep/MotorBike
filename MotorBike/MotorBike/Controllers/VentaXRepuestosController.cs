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
    [Authorize(Roles = "Admin")]
    public class VentaXRepuestosController : Controller
    {
        private readonly MotorBikeContext _context;

        public VentaXRepuestosController(MotorBikeContext context)
        {
            _context = context;
        }

        // GET: VentaXRepuestoes
        public async Task<IActionResult> Index()
        {
            var motorBikeContext = _context.VentaXRepuestos.Include(v => v.FkCategoriaNavigation).Include(v => v.FkClienteNavigation).Include(v => v.FkMecanicoNavigation).Include(v => v.FkRepuestoNavigation).Include(v => v.FkServicioNavigation).Include(v => v.FkVentaNavigation);
            return View(await motorBikeContext.ToListAsync());
        }

        // GET: VentaXRepuestoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VentaXRepuestos == null)
            {
                return NotFound();
            }

            var ventaXRepuesto = await _context.VentaXRepuestos
                .Include(v => v.FkCategoriaNavigation)
                .Include(v => v.FkClienteNavigation)
                .Include(v => v.FkMecanicoNavigation)
                .Include(v => v.FkRepuestoNavigation)
                .Include(v => v.FkServicioNavigation)
                .Include(v => v.FkVentaNavigation)
                .FirstOrDefaultAsync(m => m.IdVentaXRepuesto == id);
            if (ventaXRepuesto == null)
            {
                return NotFound();
            }

            return View(ventaXRepuesto);
        }

        // GET: VentaXRepuestoes/Create
        public IActionResult Create()
        {
            ViewData["FkCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "IdCategoria");
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            ViewData["FkMecanico"] = new SelectList(_context.Mecanicos, "IdMecanico", "IdMecanico");
            ViewData["FkRepuesto"] = new SelectList(_context.Repuestos, "IdRepuesto", "IdRepuesto");
            ViewData["FkServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio");
            ViewData["FkVenta"] = new SelectList(_context.Ventas, "IdVenta", "IdVenta");
            return View();
        }

        // POST: VentaXRepuestoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVentaXRepuesto,FkVenta,FkCategoria,FkRepuesto,FkMecanico,FkServicio,FkCliente,PrecioManoObra,Cantidad,PrecioUnitario,Subtotal,PrecioFinal")] VentaXRepuesto ventaXRepuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventaXRepuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "IdCategoria", ventaXRepuesto.FkCategoria);
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", ventaXRepuesto.FkCliente);
            ViewData["FkMecanico"] = new SelectList(_context.Mecanicos, "IdMecanico", "IdMecanico", ventaXRepuesto.FkMecanico);
            ViewData["FkRepuesto"] = new SelectList(_context.Repuestos, "IdRepuesto", "IdRepuesto", ventaXRepuesto.FkRepuesto);
            ViewData["FkServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", ventaXRepuesto.FkServicio);
            ViewData["FkVenta"] = new SelectList(_context.Ventas, "IdVenta", "IdVenta", ventaXRepuesto.FkVenta);
            return View(ventaXRepuesto);
        }

        // GET: VentaXRepuestoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VentaXRepuestos == null)
            {
                return NotFound();
            }

            var ventaXRepuesto = await _context.VentaXRepuestos.FindAsync(id);
            if (ventaXRepuesto == null)
            {
                return NotFound();
            }
            ViewData["FkCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "IdCategoria", ventaXRepuesto.FkCategoria);
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", ventaXRepuesto.FkCliente);
            ViewData["FkMecanico"] = new SelectList(_context.Mecanicos, "IdMecanico", "IdMecanico", ventaXRepuesto.FkMecanico);
            ViewData["FkRepuesto"] = new SelectList(_context.Repuestos, "IdRepuesto", "IdRepuesto", ventaXRepuesto.FkRepuesto);
            ViewData["FkServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", ventaXRepuesto.FkServicio);
            ViewData["FkVenta"] = new SelectList(_context.Ventas, "IdVenta", "IdVenta", ventaXRepuesto.FkVenta);
            return View(ventaXRepuesto);
        }

        // POST: VentaXRepuestoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVentaXRepuesto,FkVenta,FkCategoria,FkRepuesto,FkMecanico,FkServicio,FkCliente,PrecioManoObra,Cantidad,PrecioUnitario,Subtotal,PrecioFinal")] VentaXRepuesto ventaXRepuesto)
        {
            if (id != ventaXRepuesto.IdVentaXRepuesto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventaXRepuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaXRepuestoExists(ventaXRepuesto.IdVentaXRepuesto))
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
            ViewData["FkCategoria"] = new SelectList(_context.Categoria, "IdCategoria", "IdCategoria", ventaXRepuesto.FkCategoria);
            ViewData["FkCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", ventaXRepuesto.FkCliente);
            ViewData["FkMecanico"] = new SelectList(_context.Mecanicos, "IdMecanico", "IdMecanico", ventaXRepuesto.FkMecanico);
            ViewData["FkRepuesto"] = new SelectList(_context.Repuestos, "IdRepuesto", "IdRepuesto", ventaXRepuesto.FkRepuesto);
            ViewData["FkServicio"] = new SelectList(_context.Servicios, "IdServicio", "IdServicio", ventaXRepuesto.FkServicio);
            ViewData["FkVenta"] = new SelectList(_context.Ventas, "IdVenta", "IdVenta", ventaXRepuesto.FkVenta);
            return View(ventaXRepuesto);
        }

        // GET: VentaXRepuestos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VentaXRepuestos == null)
            {
                return NotFound();
            }

            var ventaXRepuesto = await _context.VentaXRepuestos
                .Include(v => v.FkCategoriaNavigation)
                .Include(v => v.FkClienteNavigation)
                .Include(v => v.FkMecanicoNavigation)
                .Include(v => v.FkRepuestoNavigation)
                .Include(v => v.FkServicioNavigation)
                .FirstOrDefaultAsync(m => m.IdVentaXRepuesto == id);
            if (ventaXRepuesto == null)
            {
                return NotFound();
            }
            else
            {
                _context.VentaXRepuestos.Remove(ventaXRepuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }

        //// POST: VentaXRepuestos/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.VentaXRepuestos == null)
        //    {
        //        return Problem("Entity set 'MotorBikeContext.VentaXRepuestos'  is null.");
        //    }
        //    var ventaXRepuesto = await _context.VentaXRepuestos.FindAsync(id);
        //    if (ventaXRepuesto != null)
        //    {
        //        _context.VentaXRepuestos.Remove(ventaXRepuesto);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool VentaXRepuestoExists(int id)
        {
          return (_context.VentaXRepuestos?.Any(e => e.IdVentaXRepuesto == id)).GetValueOrDefault();
        }
    }
}
