using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LandmarkRemark.Data;

namespace LandmarkRemark.ClientApp.src.app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PinsController : ControllerBase
    {
        private readonly userContext _context;

        public PinsController(userContext context)
        {
            _context = context;
        }

        // GET: api/Pins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pin>>> GetPin()
        {
            return await _context.Pin.ToListAsync();
        }

        // GET: api/Pins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pin>> GetPin(int id)
        {
            var pin = await _context.Pin.FindAsync(id);

            if (pin == null)
            {
                return NotFound();
            }

            return pin;
        }

        // PUT: api/Pins/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPin(int id, Pin pin)
        {
            if (id != pin.PinId)
            {
                return BadRequest();
            }

            _context.Entry(pin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PinExists(id))
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

        // POST: api/Pins
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Pin>> PostPin(Pin pin)
        {
            _context.Pin.Add(pin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPin", new { id = pin.PinId }, pin);
        }

        // DELETE: api/Pins/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pin>> DeletePin(int id)
        {
            var pin = await _context.Pin.FindAsync(id);
            if (pin == null)
            {
                return NotFound();
            }

            _context.Pin.Remove(pin);
            await _context.SaveChangesAsync();

            return pin;
        }

        private bool PinExists(int id)
        {
            return _context.Pin.Any(e => e.PinId == id);
        }
    }
}
