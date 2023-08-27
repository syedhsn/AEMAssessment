using AssessmentOne.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WellbyPlatform.Models;

namespace WellbyPlatform.Controllers
{
    [Route("api/[controller]/InsertWell")]
    [ApiController]
    public class WellController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public WellController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Well>> PostWell(Well well)
        {
            var wellTable = _context.Well;
            var matchedWell = wellTable.Where(x => x.Id == well.Id).ToList();

            if (matchedWell.Count == 1)
            {
                matchedWell[0].UniqueName = well.UniqueName;
                matchedWell[0].Latitude = well.Latitude;
                matchedWell[0].Longitude = well.Longitude;
                matchedWell[0].CreatedAt = well.CreatedAt;
                matchedWell[0].UpdatedAt = well.UpdatedAt;

                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(PostWell), well);
            }
            else
            {
                _context.Well.Add(well);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(PostWell), new { id = well.Id }, well);
            }
        }
    }
}
