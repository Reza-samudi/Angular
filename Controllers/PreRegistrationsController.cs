using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Amoozeshyar.Database;

namespace Amoozeshyar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreRegistrationsController : ControllerBase
    {
        private readonly AmoozeshyarDB _context;

        public PreRegistrationsController(AmoozeshyarDB context)
        {
            _context = context;
        }

        // GET: api/PreRegistrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreRegistration>>> GetPreRegistrations()
        {
            return await _context.PreRegistrations.ToListAsync();
        }

        // GET: api/PreRegistrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreRegistration>> GetPreRegistration(int id)
        {
            var preRegistration = await _context.PreRegistrations.FindAsync(id);

            if (preRegistration == null)
            {
                return NotFound();
            }

            return preRegistration;
        }

        // PUT: api/PreRegistrations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreRegistration(int id, PreRegistration preRegistration)
        {
            if (id != preRegistration.Id)
            {
                return BadRequest();
            }

            _context.Entry(preRegistration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreRegistrationExists(id))
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

        // POST: api/PreRegistrations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PreRegistration>> PostPreRegistration(PreRegistration preRegistration)
        {
            _context.PreRegistrations.Add(preRegistration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreRegistration", new { id = preRegistration.Id }, preRegistration);
        }

        // DELETE: api/PreRegistrations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreRegistration(int id)
        {
            var preRegistration = await _context.PreRegistrations.FindAsync(id);
            if (preRegistration == null)
            {
                return NotFound();
            }

            _context.PreRegistrations.Remove(preRegistration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PreRegistrationExists(int id)
        {
            return _context.PreRegistrations.Any(e => e.Id == id);
        }
    }
}
