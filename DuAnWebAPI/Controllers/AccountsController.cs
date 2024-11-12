using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DuAnWebData.Data;
using DuAnWebData.Model;

namespace DuAnWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly DataContext _context;

        public AccountsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accounts>>> GetAccountss()
        {
          if (_context.Accountss == null)
          {
              return NotFound();
          }
            return await _context.Accountss.ToListAsync();
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accounts>> GetAccounts(Guid id)
        {
          if (_context.Accountss == null)
          {
              return NotFound();
          }
            var accounts = await _context.Accountss.FindAsync(id);

            if (accounts == null)
            {
                return NotFound();
            }

            return accounts;
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccounts(Guid id, Accounts accounts)
        {
            if (id != accounts.AccountId)
            {
                return BadRequest();
            }

            _context.Entry(accounts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountsExists(id))
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

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Accounts>> PostAccounts(Accounts accounts)
        {
          if (_context.Accountss == null)
          {
              return Problem("Entity set 'DataContext.Accountss'  is null.");
          }
           Guid id = new Guid();
            accounts.AccountId = id;
            _context.Accountss.Add(accounts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccounts", new { id = accounts.AccountId }, accounts);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccounts(Guid id)
        {
            if (_context.Accountss == null)
            {
                return NotFound();
            }
            var accounts = await _context.Accountss.FindAsync(id);
            if (accounts == null)
            {
                return NotFound();
            }

            _context.Accountss.Remove(accounts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountsExists(Guid id)
        {
            return (_context.Accountss?.Any(e => e.AccountId == id)).GetValueOrDefault();
        }
    }
}
