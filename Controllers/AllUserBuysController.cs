using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using storeAdmin.Models;

namespace storeAdmin.Controllers
{
    [Route("AllUserBuys")]
    //AllUserBuys/buy

    [ApiController]
    public class AllUserBuysController : ControllerBase
    {
        private readonly AllBuyUserContext _context;

        public AllUserBuysController(AllBuyUserContext context)
        {
            _context = context;
        }

        // GET: api/AllUserBuys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllUserBuy>>> GetAllBuyUser()
        {
            return await _context.Buy.ToListAsync();
        }

        [Route("buy")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<AllUserBuy>>> Login(AllUserBuy customerId)
        {

            return await _context.Buy.Where(w => w.cunsumerId == customerId.cunsumerId).ToListAsync();
        }

        // GET: api/AllUserBuys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AllUserBuy>> GetAllUserBuy(int id)
        {
            var allUserBuy = await _context.Buy.FindAsync(id);

            if (allUserBuy == null)
            {
                return NotFound();
            }

            return allUserBuy;
        }

        // PUT: api/AllUserBuys/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllUserBuy(int id, AllUserBuy allUserBuy)
        {
            if (id != allUserBuy.id)
            {
                return BadRequest();
            }

            _context.Entry(allUserBuy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllUserBuyExists(id))
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

        // POST: api/AllUserBuys
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AllUserBuy>> PostAllUserBuy(AllUserBuy allUserBuy)
        {
            _context.Buy.Add(allUserBuy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllUserBuy", new { id = allUserBuy.id }, allUserBuy);
        }

        // DELETE: api/AllUserBuys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AllUserBuy>> DeleteAllUserBuy(int id)
        {
            var allUserBuy = await _context.Buy.FindAsync(id);
            if (allUserBuy == null)
            {
                return NotFound();
            }

            _context.Buy.Remove(allUserBuy);
            await _context.SaveChangesAsync();

            return allUserBuy;
        }

        private bool AllUserBuyExists(int id)
        {
            return _context.Buy.Any(e => e.id == id);
        }
    }
}
