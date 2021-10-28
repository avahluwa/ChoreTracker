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

        public ChoresController(ChoreContext context, OutsideChoresContext context2)
        {
            _context = context;
        }

        // GET: api/Chores
        [HttpGet]
        public async Task<ActionResult<DTO>> GetChores()
        {

            //in progress 10/27/2021
            List<Chore> chores  = await _context.Chores.ToListAsync();
            List<OutsideChores> outsidechores = await _context.OutsideChores.ToListAsync();

            var dto = new DTO();
            dto.Chores = chores;
            dto.outsideChores = outsidechores;

            return dto;
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

            return CreatedAtAction(nameof(GetChore), new { id = chore.Id }, chore);

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
