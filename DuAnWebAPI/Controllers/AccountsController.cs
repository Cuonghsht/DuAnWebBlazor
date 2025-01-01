using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DuAnWebData.Data;
using DuAnWebData.Model;
using DuAnWebData.Fake;
using System.Drawing.Printing;

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
        public IActionResult GetAccount(int page = 1, int pagesize =10)
        {
            var Sumdata = _context.Accountss.Count();
            var data = _context.Accountss.Skip((page-1)*pagesize)
                .Take(pagesize)
                .ToList();
            return Ok(new
            {
                TotalRecords = Sumdata, 
                Page = page,                 
                PageSize = pagesize,         
                TotalPages = (int)Math.Ceiling((double)Sumdata / pagesize), 
                Accounts = data              
            });

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
        [HttpPost("AddAccount")]
        public async Task<ActionResult<Accounts>> Add([FromBody] Accounts aa)
        {
            Accounts accounts = new Accounts()
            {
                AccountName = aa.AccountName,
                AccountPass = aa.AccountPass,
                RoleId = aa.RoleId
            };
            _context.Accountss.Add(accounts);
            await _context.SaveChangesAsync();
            return Ok("Thanh cong");
        }
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
