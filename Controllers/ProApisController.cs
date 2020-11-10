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
    [Route("ProApi")]
    [ApiController]
    public class ProApisController : ControllerBase
    {
        private readonly ProApiContext _context;

        public ProApisController(ProApiContext context)
        {
            _context = context;
        }

        // GET: api/ProApis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProApi>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/ProApis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProApi>> GetProApi(int id)
        {
            var proApi = await _context.Products.FindAsync(id);

            if (proApi == null)
            {
                return NotFound();
            }

            return proApi;
        }

        // PUT: api/ProApis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProApi(int id, ProApi proApi)
        {
            if (id != proApi.id)
            {
                return BadRequest();
            }

            _context.Entry(proApi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProApiExists(id))
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

        // POST: api/ProApis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProApi>> PostProApi(ProApi proApi)
        {
            _context.Products.Add(proApi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProApi", new { id = proApi.id }, proApi);
        }

        // DELETE: api/ProApis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProApi>> DeleteProApi(int id)
        {
            var proApi = await _context.Products.FindAsync(id);
            if (proApi == null)
            {
                return NotFound();
            }

            _context.Products.Remove(proApi);
            await _context.SaveChangesAsync();

            return proApi;
        }

        private bool ProApiExists(int id)
        {
            return _context.Products.Any(e => e.id == id);
        }
    }
}
