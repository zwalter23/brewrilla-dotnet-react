using brewrillaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace brewrillaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerItemsController : ControllerBase
    {
        private readonly BeerContext _context;

        public BeerItemsController(BeerContext context)
        {
            _context = context;
        }

        // GET: api/BeerItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BeerItem>>> GetBeerItems()
        {
            return await _context.BeerItems.ToListAsync();
        }

        // GET: api/BeerItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BeerItem>> GetBeerItem(int id)
        {
            var beerItem = await _context.BeerItems.FindAsync(id);

            if (beerItem == null)
            {
                return NotFound();
            }

            return beerItem;
        }

        // PUT: api/BeerItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeerItem(int id, BeerItem beerItem)
        {
            if (id != beerItem.id)
            {
                return BadRequest();
            }

            _context.Entry(beerItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeerItemExists(id))
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

        // POST: api/BeerItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BeerItem>> PostBeerItem(BeerItem beerItem)
        {
            _context.BeerItems.Add(beerItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBeerItem), new { id = beerItem.id }, beerItem);
        }

        // DELETE: api/BeerItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeerItem(int id)
        {
            var beerItem = await _context.BeerItems.FindAsync(id);
            if (beerItem == null)
            {
                return NotFound();
            }

            _context.BeerItems.Remove(beerItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeerItemExists(int id)
        {
            return _context.BeerItems.Any(e => e.id == id);
        }
    }
}
