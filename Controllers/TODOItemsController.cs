using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TODOList.Data;
using TODOList.Models;

namespace TODOList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TODOItemsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public TODOItemsController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/TODOItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TODOItem>>> GetTODOItem()
        {
            return await _context.TODOItem.ToListAsync();
        }

        // GET: api/TODOItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TODOItem>> GetTODOItem(int id)
        {
            var tODOItem = await _context.TODOItem.FindAsync(id);

            if (tODOItem == null)
            {
                return NotFound();
            }

            return tODOItem;
        }

        // PUT: api/TODOItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTODOItem(int id, TODOItem tODOItem)
        {
            if (id != tODOItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(tODOItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TODOItemExists(id))
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

        // POST: api/TODOItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TODOItem>> PostTODOItem(TODOItem tODOItem)
        {
            _context.TODOItem.Add(tODOItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTODOItem", new { id = tODOItem.Id }, tODOItem);
        }

        // DELETE: api/TODOItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTODOItem(int id)
        {
            var tODOItem = await _context.TODOItem.FindAsync(id);
            if (tODOItem == null)
            {
                return NotFound();
            }

            _context.TODOItem.Remove(tODOItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TODOItemExists(int id)
        {
            return _context.TODOItem.Any(e => e.Id == id);
        }
    }
}
