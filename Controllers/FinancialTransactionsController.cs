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
    public class FinancialTransactionsController : ControllerBase
    {
        private readonly AmoozeshyarDB _context;

        public FinancialTransactionsController(AmoozeshyarDB context)
        {
            _context = context;
        }

        // GET: api/FinancialTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinancialTransaction>>> GetFinancialTransactions()
        {
            return await _context.FinancialTransactions.ToListAsync();
        }

        // GET: api/FinancialTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinancialTransaction>> GetFinancialTransaction(int id)
        {
            var financialTransaction = await _context.FinancialTransactions.FindAsync(id);

            if (financialTransaction == null)
            {
                return NotFound();
            }

            return financialTransaction;
        }

        // PUT: api/FinancialTransactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinancialTransaction(int id, FinancialTransaction financialTransaction)
        {
            if (id != financialTransaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(financialTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancialTransactionExists(id))
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

        // POST: api/FinancialTransactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FinancialTransaction>> PostFinancialTransaction(FinancialTransaction financialTransaction)
        {
            _context.FinancialTransactions.Add(financialTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinancialTransaction", new { id = financialTransaction.Id }, financialTransaction);
        }

        // DELETE: api/FinancialTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinancialTransaction(int id)
        {
            var financialTransaction = await _context.FinancialTransactions.FindAsync(id);
            if (financialTransaction == null)
            {
                return NotFound();
            }

            _context.FinancialTransactions.Remove(financialTransaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinancialTransactionExists(int id)
        {
            return _context.FinancialTransactions.Any(e => e.Id == id);
        }
    }
}
