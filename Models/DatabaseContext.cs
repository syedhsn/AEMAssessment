using AssessmentOne.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WellbyPlatform.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }
        public DbSet<Platform> Platform { get; set; }
        public DbSet<Well> Well { get; set; }
    }
}
