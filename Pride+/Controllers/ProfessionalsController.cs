using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pride_;
using Pride_.Domain;

namespace Pride_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalsController : ControllerBase
    {
        private readonly PrideMoreContext _context;

        public ProfessionalsController(PrideMoreContext context)
        {
            _context = context;
        }

        // GET: api/Professionals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professional>>> Getprofessionals()
        {
            return await _context.professionals.ToListAsync();
        }

        // GET: api/Professionals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Professional>> GetProfessional(string id)
        {
            var professional = await _context.professionals.FindAsync(id);

            if (professional == null)
            {
                return NotFound();
            }

            return professional;
        }

        // PUT: api/Professionals/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessional(string id, Professional professional)
        {
            if (id != professional.Email)
            {
                return BadRequest();
            }

            _context.Entry(professional).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessionalExists(id))
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

        // POST: api/Professionals
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Professional>> PostProfessional(Professional professional)
        {
            _context.professionals.Add(professional);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProfessionalExists(professional.Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProfessional", new { id = professional.Email }, professional);
        }

        // DELETE: api/Professionals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Professional>> DeleteProfessional(string id)
        {
            var professional = await _context.professionals.FindAsync(id);
            if (professional == null)
            {
                return NotFound();
            }

            _context.professionals.Remove(professional);
            await _context.SaveChangesAsync();

            return professional;
        }

        private bool ProfessionalExists(string id)
        {
            return _context.professionals.Any(e => e.Email == id);
        }
    }
}
