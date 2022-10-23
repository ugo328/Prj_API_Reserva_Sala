using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaSalas.Context;
using AgendaSalas.Models;

namespace AgendaSalas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisponibilidadeSalaController : ControllerBase
    {
        private readonly APIDbContext _context;

        public DisponibilidadeSalaController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/DisponibilidadeSala
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DisponibilidadeSala>>> GetDisponibilidadeSala()
        {
            return await _context.DisponibilidadeSala.ToListAsync();
        }

        // GET: api/DisponibilidadeSala/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DisponibilidadeSala>> GetDisponibilidadeSala(int id)
        {
            var disponibilidadeSala = await _context.DisponibilidadeSala.FindAsync(id);

            if (disponibilidadeSala == null)
            {
                return NotFound();
            }

            return disponibilidadeSala;
        }

        // PUT: api/DisponibilidadeSala/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisponibilidadeSala(int id, DisponibilidadeSala disponibilidadeSala)
        {
            if (id != disponibilidadeSala.DisponibilidadeSalaId)
            {
                return BadRequest();
            }

            _context.Entry(disponibilidadeSala).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisponibilidadeSalaExists(id))
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

        // POST: api/DisponibilidadeSala
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DisponibilidadeSala>> PostDisponibilidadeSala(DisponibilidadeSala disponibilidadeSala)
        {
            _context.DisponibilidadeSala.Add(disponibilidadeSala);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisponibilidadeSala", new { id = disponibilidadeSala.DisponibilidadeSalaId }, disponibilidadeSala);
        }

        // DELETE: api/DisponibilidadeSala/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDisponibilidadeSala(int id)
        {
            var disponibilidadeSala = await _context.DisponibilidadeSala.FindAsync(id);
            if (disponibilidadeSala == null)
            {
                return NotFound();
            }

            _context.DisponibilidadeSala.Remove(disponibilidadeSala);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DisponibilidadeSalaExists(int id)
        {
            return _context.DisponibilidadeSala.Any(e => e.DisponibilidadeSalaId == id);
        }
    }
}
