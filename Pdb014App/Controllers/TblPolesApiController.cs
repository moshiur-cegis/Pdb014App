using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB;
using Pdb014App.Repository;

namespace Pdb014App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblPolesApiController : ControllerBase
    {
        private readonly PdbDbContext _context;

        public TblPolesApiController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: api/TblPolesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPole>>> GetTblPole()
        {
            return await _context.TblPole.ToListAsync();
        }

        // GET: api/TblPolesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblPole>> GetTblPole(string id)
        {
            var tblPole = await _context.TblPole.FindAsync(id);

            if (tblPole == null)
            {
                return NotFound();
            }

            return tblPole;
        }

        // PUT: api/TblPolesApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPole(string id, TblPole tblPole)
        {
            if (id != tblPole.PoleId)
            {
                return BadRequest();
            }

            _context.Entry(tblPole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPoleExists(id))
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

        // POST: api/TblPolesApi
        [HttpPost]
        public async Task<ActionResult<TblPole>> PostTblPole(TblPole tblPole)
        {
            _context.TblPole.Add(tblPole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblPole", new { id = tblPole.PoleId }, tblPole);
        }

        // DELETE: api/TblPolesApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TblPole>> DeleteTblPole(string id)
        {
            var tblPole = await _context.TblPole.FindAsync(id);
            if (tblPole == null)
            {
                return NotFound();
            }

            _context.TblPole.Remove(tblPole);
            await _context.SaveChangesAsync();

            return tblPole;
        }

        private bool TblPoleExists(string id)
        {
            return _context.TblPole.Any(e => e.PoleId == id);
        }
    }
}
