using System;
using Covid_19_Tracker.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Covid_19_Tracker.Persistence
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Addresse> Addresses { get; set;}
        public DbSet<CasPositif> CasPositifs { get; set; }
        public DbSet<CasSuivi> CasSuivis { get; set; }
        public DbSet<FicheSuivi> FichesSuivi { get; set; }
        public DbSet<Personne> Personnes { get; set; }
    }
}
