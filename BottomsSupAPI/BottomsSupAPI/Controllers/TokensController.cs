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
        private ApplicationDbContext db = new ApplicationDbContext();

      


        public TokensController(ApplicationDbContext context)
        {
            db = context;
        }

        // GET: api/Tokens
        [HttpGet]
        public IEnumerable<Tokens> GetTokens()
        {
            var tokens= from r in db.Tokens
                          select new
                          {
                              Id = r.TokenId,
                              Price=r.Price,
                              Name = r.Name,
                              IsComplete=r.IsComplete
                          };
            return tokens;
        }

        // GET: api/Tokens/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTokens([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tokens = await db.Tokens.FindAsync(id);

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

            db.Entry(tokens).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

            db.Tokens.Add(tokens);
            await db.SaveChangesAsync();

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

            var tokens = await db.Tokens.FindAsync(id);
            if (tokens == null)
            {
                return NotFound();
            }

            db.Tokens.Remove(tokens);
            await db.SaveChangesAsync();

            return Ok(tokens);
        }

        private bool TokensExists(int id)
        {
            return db.Tokens.Any(e => e.TokenId == id);
        }
    }
}