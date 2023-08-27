using AssessmentOne.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WellbyPlatform.Models;

namespace WellbyPlatform.Controllers
{
    [Route("api/[controller]/InsertPlatform")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PlatformController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Platform>> PostPlatform(Platform platform)
        {
            var platformTable = _context.Platform;
            var matchedPlatform = platformTable.Where(x => x.Id == platform.Id).ToList();

            if (matchedPlatform.Count == 1)
            {
                matchedPlatform[0].UniqueName = platform.UniqueName;
                matchedPlatform[0].Latitude = platform.Latitude;
                matchedPlatform[0].Longitude = platform.Longitude;
                matchedPlatform[0].CreatedAt = platform.CreatedAt;
                matchedPlatform[0].UpdatedAt = platform.UpdatedAt;

                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(PostPlatform), platform);
            }
            else
            {
                _context.Platform.Add(platform);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(PostPlatform), new { id = platform.Id }, platform);
            }
        }
    }
}
