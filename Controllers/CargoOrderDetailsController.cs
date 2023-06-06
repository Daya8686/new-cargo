using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CargoManagerSystem.Models;
using CargoManagerSystem.Modules;

namespace CargoManagerSystem.Controllers
{
    [Route("api/CargoOrderDetails")]
    [ApiController]
    public class CargoOrderDetailsController : ControllerBase
    {
        private readonly MyCargoDBContext _context;

        public CargoOrderDetailsController(MyCargoDBContext context)
        {
            _context = context;
        }

        // GET: api/CargoOrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CargoOrderDetails>>> GetCargoOderDetails()
        {
          if (_context.CargoOderDetails == null)
          {
              return NotFound();
          }
            return await _context.CargoOderDetails.ToListAsync();
        }

        // GET: api/CargoOrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CargoOrderDetails>> GetCargoOrderDetails(int id)
        {
          if (_context.CargoOderDetails == null)
          {
              return NotFound();
          }
            var cargoOrderDetails = await _context.CargoOderDetails.FindAsync(id);

            if (cargoOrderDetails == null)
            {
                return NotFound();
            }

            return cargoOrderDetails;
        }

        // PUT: api/CargoOrderDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargoOrderDetails(int id, CargoOrderDetails cargoOrderDetails)
        {
            if (id != cargoOrderDetails.CargoorderDetailsId)
            {
                return BadRequest();
            }

            _context.Entry(cargoOrderDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargoOrderDetailsExists(id))
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

        // POST: api/CargoOrderDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CargoOrderDetails>> PostCargoOrderDetails(CargoOrderDetails cargoOrderDetails)
        {
          if (_context.CargoOderDetails == null)
          {
              return Problem("Entity set 'MyCargoDBContext.CargoOderDetails'  is null.");
          }
            _context.CargoOderDetails.Add(cargoOrderDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCargoOrderDetails", new { id = cargoOrderDetails.CargoorderDetailsId }, cargoOrderDetails);
        }

        // DELETE: api/CargoOrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoOrderDetails(int id)
        {
            if (_context.CargoOderDetails == null)
            {
                return NotFound();
            }
            var cargoOrderDetails = await _context.CargoOderDetails.FindAsync(id);
            if (cargoOrderDetails == null)
            {
                return NotFound();
            }

            _context.CargoOderDetails.Remove(cargoOrderDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CargoOrderDetailsExists(int id)
        {
            return (_context.CargoOderDetails?.Any(e => e.CargoorderDetailsId == id)).GetValueOrDefault();
        }
    }
}
