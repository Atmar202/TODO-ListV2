﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TODOList.Models;
using TODOList.Data;
using Microsoft.AspNetCore.Authorization;

namespace TODOList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HomeworkController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public HomeworkController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Homework
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Homework>>> GetHomework()
        {
            return await _context.Homework.ToListAsync();
        }

        // GET: api/Homework/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Homework>> GetHomework(int id)
        {
            var homework = await _context.Homework.FindAsync(id);

            if (homework == null)
            {
                return NotFound();
            }

            return homework;
        }

        // PUT: api/Homework/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomework(int id, Homework homework)
        {
            if (id != homework.Id)
            {
                return BadRequest();
            }

            _context.Entry(homework).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeworkExists(id))
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

        // POST: api/Homework
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Homework>> PostHomework(Homework homework)
        {
            _context.Homework.Add(homework);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHomework", new { id = homework.Id }, homework);
        }

        // DELETE: api/Homework/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomework(int id)
        {
            var homework = await _context.Homework.FindAsync(id);
            if (homework == null)
            {
                return NotFound();
            }

            _context.Homework.Remove(homework);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HomeworkExists(int id)
        {
            return _context.Homework.Any(e => e.Id == id);
        }
    }
}
