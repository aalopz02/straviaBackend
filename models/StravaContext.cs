using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using models;

namespace straviaBackend.models
{
    public class StravaContext : DbContext
    {
        public StravaContext(DbContextOptions<StravaContext> options) : base(options)
        {
        }

        public DbSet<ModelCarrera> Carreras { get; set; }
        public DbSet<ModelUsuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}

