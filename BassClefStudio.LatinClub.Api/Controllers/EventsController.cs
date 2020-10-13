using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BassClefStudio.LatinClub.Api.Data;
using BassClefStudio.LatinClub.Core.Events;

namespace BassClefStudio.LatinClub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ClubContext _context;

        public EventsController(ClubContext context)
        {
            _context = context;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClubEvent>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClubEvent>> GetEvent(int id)
        {
            var clubEvent = await _context.Events.FindAsync(id);

            if (clubEvent == null)
            {
                return NotFound();
            }

            return clubEvent;
        }

        // POST: api/Events
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClubEvent>> PostEvent(ClubEvent clubEvent)
        {
            _context.Events.Add(clubEvent);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvent), new { id = clubEvent.Id }, clubEvent);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClubEvent>> DeleteEvent(int id)
        {
            var clubEvent = await _context.Events.FindAsync(id);
            if (clubEvent == null)
            {
                return NotFound();
            }

            _context.Events.Remove(clubEvent);
            await _context.SaveChangesAsync();

            return clubEvent;
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
