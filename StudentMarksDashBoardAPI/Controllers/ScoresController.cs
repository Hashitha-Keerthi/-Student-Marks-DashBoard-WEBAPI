﻿using System;
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
    public class ScoresController : ControllerBase
    {
        private readonly DataContext _context;

        public ScoresController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Scores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Score>>> Getscores()
        {
          if (_context.scores == null)
          {
              return NotFound();
          }
            return await _context.scores.ToListAsync();
        }

        // GET: api/Scores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Score>> GetScore(int id)
        {
          if (_context.scores == null)
          {
              return NotFound();
          }
            var score = await _context.scores.FindAsync(id);

            if (score == null)
            {
                return NotFound();
            }

            return score;
        }

        // PUT: api/Scores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScore(int id, Score score)
        {
            if (id != score.Id)
            {
                return BadRequest();
            }

            _context.Entry(score).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoreExists(id))
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

        // POST: api/Scores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Score>> PostScore(Score score)
        {
          if (_context.scores == null)
          {
              return Problem("Entity set 'DataContext.scores'  is null.");
          }
            _context.scores.Add(score);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScore", new { id = score.Id }, score);
        }

        // DELETE: api/Scores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScore(int id)
        {
            if (_context.scores == null)
            {
                return NotFound();
            }
            var score = await _context.scores.FindAsync(id);
            if (score == null)
            {
                return NotFound();
            }

            _context.scores.Remove(score);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScoreExists(int id)
        {
            return (_context.scores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
