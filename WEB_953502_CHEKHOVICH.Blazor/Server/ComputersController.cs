using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_953502_CHEKHOVICH.Data;
using WEB_953502_CHEKHOVICH.Entities;

namespace WEB_953502_CHEKHOVICH.Blazor.Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComputersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Computer>>> GetComputers(int? group)
        {
            var dishes = _context.Computers.Where(
            d => !group.HasValue || d.ComputerGroupId == group.Value);
            return await dishes.ToListAsync();
        }

        // GET: api/Computers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Computer>> GetComputer(int id)
        {
            var computer = await _context.Computers.FindAsync(id);

            if (computer == null)
            {
                return NotFound();
            }

            return computer;
        }

        // PUT: api/Computers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComputer(int id, Computer computer)
        {
            if (id != computer.ComputerId)
            {
                return BadRequest();
            }

            _context.Entry(computer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputerExists(id))
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

        // POST: api/Computers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Computer>> PostComputer(Computer computer)
        {
            _context.Computers.Add(computer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComputer", new { id = computer.ComputerId }, computer);
        }

        // DELETE: api/Computers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComputer(int id)
        {
            var computer = await _context.Computers.FindAsync(id);
            if (computer == null)
            {
                return NotFound();
            }

            _context.Computers.Remove(computer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComputerExists(int id)
        {
            return _context.Computers.Any(e => e.ComputerId == id);
        }
    }
}
