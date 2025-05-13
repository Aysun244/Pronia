using Microsoft.EntityFrameworkCore;
using Pronia_BB104.Models;
using Pronia_BB104.Models;

namespace Pronia_BB104.Context
{
    public class ProniaDbContext : DbContext
    {
        public ProniaDbContext(DbContextOptions<ProniaDbContext> options) : base(options)
        {
        }

        public DbSet<Slider>Sliders { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
