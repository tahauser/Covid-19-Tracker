using System;
using Microsoft.EntityFrameworkCore;

namespace Covid_19_Tracker.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        //public DbSet<Entity> Entities {get; set;}
    }
}
