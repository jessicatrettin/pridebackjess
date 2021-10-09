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
    public class PatientsController : ControllerBase
    {
        private readonly PrideMoreContext _context;

        public PatientsController(PrideMoreContext context)
        {
            _context = context;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> Getpacients()
        {
            return await _context.pacients.ToListAsync();
        }

        // GET: api/Patients/jessica@gmail.com
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(string id)
        {
            var patient = await _context.pacients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        // PUT: api/Patients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(string id, Patient patient)
        {
            if (id != patient.Email)
            {
                return BadRequest();
            }

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
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

        // POST: api/Patients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            _context.pacients.Add(patient);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PatientExists(patient.Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPatient", new { id = patient.Email }, patient);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patient>> DeletePatient(string id)
        {
            var patient = await _context.pacients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.pacients.Remove(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        private bool PatientExists(string id)
        {
            return _context.pacients.Any(e => e.Email == id);
        }
    }
}
