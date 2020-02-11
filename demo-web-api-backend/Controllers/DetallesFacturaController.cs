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
    public class DetallesFacturaController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public DetallesFacturaController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/DetallesFactura
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleFactura>>> GetDetallesFactura()
        {
            return await _context.DetallesFactura.ToListAsync();
        }

        // GET: api/DetallesFactura/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleFactura>> GetDetalleFactura(int id)
        {
            var detalleFactura = await _context.DetallesFactura.FindAsync(id);

            if (detalleFactura == null)
            {
                return NotFound();
            }

            return detalleFactura;
        }

        // PUT: api/DetallesFactura/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleFactura(int id, DetalleFactura detalleFactura)
        {
            if (id != detalleFactura.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleFactura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleFacturaExists(id))
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

        // POST: api/DetallesFactura
        [HttpPost]
        public async Task<ActionResult<DetalleFactura>> PostDetalleFactura(DetalleFactura detalleFactura)
        {
            _context.DetallesFactura.Add(detalleFactura);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleFactura", new { id = detalleFactura.Id }, detalleFactura);
        }

        // DELETE: api/DetallesFactura/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetalleFactura>> DeleteDetalleFactura(int id)
        {
            var detalleFactura = await _context.DetallesFactura.FindAsync(id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            _context.DetallesFactura.Remove(detalleFactura);
            await _context.SaveChangesAsync();

            return detalleFactura;
        }

        private bool DetalleFacturaExists(int id)
        {
            return _context.DetallesFactura.Any(e => e.Id == id);
        }
    }
}
