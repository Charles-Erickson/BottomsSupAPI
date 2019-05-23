using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BottomsSupAPI.Models;

namespace BottomsSupAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly TokensContext _context;

        public TokensController(TokensContext context)
        {
            _context = context;
        }

        // GET: api/Tokens
        [HttpGet]
        public IEnumerable<Tokens> GetTokens()
        {
            return _context.Tokens;
        }

        // GET: api/Tokens/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTokens([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tokens = await _context.Tokens.FindAsync(id);

            if (tokens == null)
            {
                return NotFound();
            }

            return Ok(tokens);
        }

        // PUT: api/Tokens/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTokens([FromRoute] int id, [FromBody] Tokens tokens)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tokens.TokenId)
            {
                return BadRequest();
            }

            _context.Entry(tokens).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TokensExists(id))
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

        // POST: api/Tokens
        [HttpPost]
        public async Task<IActionResult> PostTokens([FromBody] Tokens tokens)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tokens.Add(tokens);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTokens", new { id = tokens.TokenId }, tokens);
        }

        // DELETE: api/Tokens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTokens([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tokens = await _context.Tokens.FindAsync(id);
            if (tokens == null)
            {
                return NotFound();
            }

            _context.Tokens.Remove(tokens);
            await _context.SaveChangesAsync();

            return Ok(tokens);
        }

        private bool TokensExists(int id)
        {
            return _context.Tokens.Any(e => e.TokenId == id);
        }
    }
}