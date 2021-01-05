using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Amoozeshyar.Database;
using Amoozeshyar.Models.Requests;
using Amoozeshyar.Models.Responses;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Amoozeshyar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternsController : ControllerBase
    {
        private readonly AmoozeshyarDB _context;

        public InternsController(AmoozeshyarDB context)
        {
            _context = context;
        }

        // GET: api/Interns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intern>>> GetInterns()
        {
            return await _context.Interns.ToListAsync();
        }

        // GET: api/Interns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Intern>> GetIntern(int id)
        {
            var intern = await _context.Interns.FindAsync(id);

            if (intern == null)
            {
                return NotFound();
            }

            return intern;
        }
        // PUT: api/Interns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntern(int id, Intern intern)
        {
            if (id != intern.Id)
            {
                return BadRequest();
            }
            _context.Entry(intern).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternExists(id))
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
        // POST: api/Interns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Intern>> PostIntern(RegisterRequest  registerRequest)
        {
                  byte[] salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: registerRequest.Password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));


            var intern = new Intern {
                Address="",
                Mobile=registerRequest.Mobile,
                Firstname=registerRequest.Firstname,
                Lastname=registerRequest.Lastname,
                Password=hashed,
                Salt=salt
            };
            try{
            _context.Interns.Add(intern);
            await _context.SaveChangesAsync();
            }
            catch{
               return Ok (new RegisterResponse{
                   IsSuccess = false,
                   Message =" شماره تلفن وارد شده تکراری است "
               }) ;
            }
            return Ok(new RegisterResponse
            {
                IsSuccess = true ,
                Message = "با موفقیت ثبت شد"
            });
        }
        // DELETE: api/Interns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntern(int id)
        {
            var intern = await _context.Interns.FindAsync(id);
            if (intern == null)
            {
                return NotFound();
            }

            _context.Interns.Remove(intern);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InternExists(int id)
        {
            return _context.Interns.Any(e => e.Id == id);
        }
    }
}
