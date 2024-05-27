using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Truck_Microservice.Data;
using Truck_Microservice.Models;

namespace Truck_Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly TruckContext _context;

        public StockController(TruckContext context)
        {
            _context = context;
        }

        [HttpPost("loading")]
        public async Task<IActionResult> LoadStock([FromBody] StockLoadingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validate stock loading request
            // Implement validation logic here

            // Assuming successful validation, proceed with loading
            _context.StockItems.AddRange(request.Items);
            await _context.SaveChangesAsync();

            return Ok(request);
        }

        [HttpPost("offloading")]
        public async Task<IActionResult> UnloadStock([FromBody] StockOffloadingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validate stock offloading request
            // Implement validation logic here

            // Assuming successful validation, proceed with offloading
            foreach (var item in request.Items)
            {
                var existingItem = _context.StockItems.FirstOrDefault(s => s.StockItemId == item.StockItemId);
                if (existingItem != null)
                {
                    existingItem.Quantity -= item.Quantity;
                    // Update other properties as needed
                }
                // Handle case if item not found or quantity exceeds available quantity
            }

            await _context.SaveChangesAsync();

            return Ok(request);
        }
    }
}
