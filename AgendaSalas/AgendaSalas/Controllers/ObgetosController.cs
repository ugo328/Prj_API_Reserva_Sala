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
    public class ObgetosController : ControllerBase
    {
        private readonly APIDbContext _context;

        public ObgetosController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/Obgetos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Obgetos>>> GetObgetos()
        {
            return await _context.Obgetos.ToListAsync();
        }

        // GET: api/Obgetos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Obgetos>> GetObgetos(int id)
        {
            var obgetos = await _context.Obgetos.FindAsync(id);

            if (obgetos == null)
            {
                return NotFound();
            }

            return obgetos;
        }

        // PUT: api/Obgetos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObgetos(int id, Obgetos obgetos)
        {
            if (id != obgetos.ObgetosID)
            {
                return BadRequest();
            }

            _context.Entry(obgetos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObgetosExists(id))
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

        // POST: api/Obgetos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Obgetos>> PostObgetos(Obgetos obgetos)
        {
            _context.Obgetos.Add(obgetos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObgetos", new { id = obgetos.ObgetosID }, obgetos);
        }

        // DELETE: api/Obgetos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObgetos(int id)
        {
            var obgetos = await _context.Obgetos.FindAsync(id);
            if (obgetos == null)
            {
                return NotFound();
            }

            _context.Obgetos.Remove(obgetos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObgetosExists(int id)
        {
            return _context.Obgetos.Any(e => e.ObgetosID == id);
        }
    }
}
