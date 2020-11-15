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

        public DbSet<ModelCarrera> carreras { get; set; }
        public DbSet<ModelUsuario> usuario { get; set; }
        public DbSet<ModelCategoria> categorias { get; set; }
        public DbSet<ModelPatrocinador> patrocinadores { get; set; }
        public DbSet<ModelTipoActividad> tiposactividades { get; set; }
        public DbSet<Modelcategoriasporcarrera> categoriasporcarrera { get; set; }
        public DbSet<Modelpatrocinadoresporcarrera> patrocinadoresporcarrera { get; set; }
        public DbSet<ModelSiguiendo> seguidores { get; set; }
        public DbSet<ModelActividad> actividad { get; set; }


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

