using Availabilities2.Models;
using Microsoft.EntityFrameworkCore;

namespace Availabilities2.Data
{
    public class AvailabilityUIContext : DbContext
    {
        public AvailabilityUIContext(DbContextOptions<AvailabilityUIContext> options) : base(options)
        {
        }

        public DbSet<Availability> Availabilities { get; set; }
    }
}