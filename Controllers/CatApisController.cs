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
    [Route("CatApi")]
    [ApiController]
    public class CatApisController : ControllerBase
    {
        private readonly CatApiContext _context;

        public CatApisController(CatApiContext context)
        {
            _context = context;
        }

        // GET: api/CatApis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatApi>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        // GET: api/CatApis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatApi>> GetCatApi(int id)
        {
            var catApi = await _context.Categories.FindAsync(id);

            if (catApi == null)
            {
                return NotFound();
            }

            return catApi;
        }

        // PUT: api/CatApis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatApi(int id, CatApi catApi)
        {
            if (id != catApi.id)
            {
                return BadRequest();
            }

            _context.Entry(catApi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatApiExists(id))
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

        // POST: api/CatApis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CatApi>> PostCatApi(CatApi catApi)
        {
            _context.Categories.Add(catApi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatApi", new { id = catApi.id }, catApi);
        }

        // DELETE: api/CatApis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatApi>> DeleteCatApi(int id)
        {
            var catApi = await _context.Categories.FindAsync(id);
            if (catApi == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(catApi);
            await _context.SaveChangesAsync();

            return catApi;
        }

        private bool CatApiExists(int id)
        {
            return _context.Categories.Any(e => e.id == id);
        }
    }
}
