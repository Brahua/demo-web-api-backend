using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using demo_web_api_backend.Context;
using demo_web_api_backend.Entities;

namespace demo_web_api_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public FacturasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Facturas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factura>>> GetFacturas()
        {
            return await _context.Facturas.Include(factura => factura.ListaDetalleFactura).ToListAsync();
        }

        // GET: api/Facturas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Factura>> GetFactura(int id)
        {
            var factura = await _context.Facturas.Include(factura => factura.ListaDetalleFactura).FirstOrDefaultAsync(factura => factura.Id == id);

            if (factura == null)
            {
                return NotFound();
            }

            return factura;
        }

        // PUT: api/Facturas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactura(int id, Factura factura)
        {
            if (id != factura.Id)
            {
                return BadRequest();
            }

            _context.Entry(factura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Facturas
        [HttpPost]
        public async Task<ActionResult<Factura>> PostFactura(Factura factura)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Facturas.Add(factura);
                    if (factura.ListaDetalleFactura != null)
                    {
                        foreach (DetalleFactura detalle in factura.ListaDetalleFactura)
                        {
                            detalle.FacturaId = factura.Id;
                            _context.DetallesFactura.Add(detalle);
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFactura", new { id = factura.Id }, factura);
        }

        // DELETE: api/Facturas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Factura>> DeleteFactura(int id)
        {
            var factura = await _context.Facturas.Include(factura => factura.ListaDetalleFactura).FirstOrDefaultAsync(factura => factura.Id == id);
            if (factura == null)
            {
                return NotFound();
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    List<DetalleFactura> listaDetalleFacturas = factura.ListaDetalleFactura;
                    foreach (var detalle in listaDetalleFacturas)
                    {
                        _context.DetallesFactura.Remove(detalle);
                    }

                    _context.Facturas.Remove(factura);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            await _context.SaveChangesAsync();
            return factura;
        }

        private bool FacturaExists(int id)
        {
            return _context.Facturas.Any(e => e.Id == id);
        }
    }
}
