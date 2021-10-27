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
    public class ChoresController : ControllerBase
    {
        private readonly ChoreContext _context;

        public ChoresController(ChoreContext context)
        {
            _context = context;
        }

        // GET: api/Chores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chore>>> GetChores()
        {
            return await _context.Chores.ToListAsync();
        }

        // GET: api/Chores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chore>> GetChore(long id)
        {
            var chore = await _context.Chores.FindAsync(id);

            if (chore == null)
            {
                return NotFound();
            }

            return chore;
        }

        // PUT: api/Chores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChore(long id, Chore chore)
        {
            if (id != chore.Id)
            {
                return BadRequest();
            }

            _context.Entry(chore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChoreExists(id))
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

        // POST: api/Chores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chore>> PostChore(Chore chore)
        {
            _context.Chores.Add(chore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChore", new { id = chore.Id }, chore);
        }

        // DELETE: api/Chores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChore(long id)
        {
            var chore = await _context.Chores.FindAsync(id);
            if (chore == null)
            {
                return NotFound();
            }

            _context.Chores.Remove(chore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChoreExists(long id)
        {
            return _context.Chores.Any(e => e.Id == id);
        }
    }
}
