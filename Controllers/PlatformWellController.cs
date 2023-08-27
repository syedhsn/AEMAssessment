using AssessmentOne.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WellbyPlatform.Models;

namespace WellbyPlatform.Controllers
{
    [Route("api/[controller]/GetPlatformWellActual")]
    [ApiController]
    [Authorize]
    public class PlatformWellController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PlatformWellController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Platform> GetWellbyPlatform()
        {
            var wellByPlatform = _context.Platform.Select(x => new Platform
                {
                    Id = x.Id,
                    UniqueName = x.UniqueName,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    UpdatedAt = x.UpdatedAt,
                    Well = x.Well.Select(y => new Well
                    {
                        Id = y.Id,
                        PlatformId = y.PlatformId,
                        UniqueName = y.UniqueName,
                        Latitude = y.Latitude,
                        Longitude = y.Longitude,
                        UpdatedAt = y.UpdatedAt,
                    })
                }).ToList();

            return wellByPlatform;
        }
    }
}
