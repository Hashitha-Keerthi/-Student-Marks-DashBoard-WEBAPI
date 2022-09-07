using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentMarksDashBoardAPI.Data;
using StudentMarksDashBoardAPI.Models;

namespace StudentMarksDashBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectModulesController : ControllerBase
    {
        private readonly DataContext _context;

        public SubjectModulesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/SubjectModules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectModule>>> GetsubjectModules()
        {
          if (_context.subjectModules == null)
          {
              return NotFound();
          }
            return await _context.subjectModules.ToListAsync();
        }

        // GET: api/SubjectModules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectModule>> GetSubjectModule(int id)
        {
          if (_context.subjectModules == null)
          {
              return NotFound();
          }
            var subjectModule = await _context.subjectModules.FindAsync(id);

            if (subjectModule == null)
            {
                return NotFound();
            }

            return subjectModule;
        }

        // PUT: api/SubjectModules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubjectModule(int id, SubjectModule subjectModule)
        {
            if (id != subjectModule.Id)
            {
                return BadRequest();
            }

            _context.Entry(subjectModule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectModuleExists(id))
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

        // POST: api/SubjectModules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubjectModule>> PostSubjectModule(SubjectModule subjectModule)
        {
          if (_context.subjectModules == null)
          {
              return Problem("Entity set 'DataContext.subjectModules'  is null.");
          }
            _context.subjectModules.Add(subjectModule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubjectModule", new { id = subjectModule.Id }, subjectModule);
        }

        // DELETE: api/SubjectModules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectModule(int id)
        {
            if (_context.subjectModules == null)
            {
                return NotFound();
            }
            var subjectModule = await _context.subjectModules.FindAsync(id);
            if (subjectModule == null)
            {
                return NotFound();
            }

            _context.subjectModules.Remove(subjectModule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubjectModuleExists(int id)
        {
            return (_context.subjectModules?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
