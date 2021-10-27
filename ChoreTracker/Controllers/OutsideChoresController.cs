using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChoreTracker.Models;

namespace ChoreTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutsideChoresController : ControllerBase
    {
        private readonly OutsideChoresContext _context;

        public OutsideChoresController(OutsideChoresContext context)
        {
            _context = context;
        }

        // GET: api/OutsideChores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OutsideChores>>> GetOutsideChores()
        {
            return await _context.OutsideChores.ToListAsync();
        }

        // GET: api/OutsideChores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OutsideChores>> GetOutsideChores(long id)
        {
            var outsideChores = await _context.OutsideChores.FindAsync(id);

            if (outsideChores == null)
            {
                return NotFound();
            }

            return outsideChores;
        }

        // PUT: api/OutsideChores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOutsideChores(long id, OutsideChores outsideChores)
        {
            if (id != outsideChores.Id)
            {
                return BadRequest();
            }

            _context.Entry(outsideChores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OutsideChoresExists(id))
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

        // POST: api/OutsideChores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OutsideChores>> PostOutsideChores(OutsideChores outsideChores)
        {
            _context.OutsideChores.Add(outsideChores);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOutsideChores), new { id = outsideChores.Id }, outsideChores);
        }

        // DELETE: api/OutsideChores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOutsideChores(long id)
        {
            var outsideChores = await _context.OutsideChores.FindAsync(id);
            if (outsideChores == null)
            {
                return NotFound();
            }

            _context.OutsideChores.Remove(outsideChores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OutsideChoresExists(long id)
        {
            return _context.OutsideChores.Any(e => e.Id == id);
        }
    }
}
