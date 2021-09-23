using System;
using VetPet.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace VetPet.App.Persistencia
{
    public class Context : DbContext
    {
        // Entities
        public DbSet<Persona> Personas {get; set;}
        public DbSet<Propietario> Propietarios {get; set;}
        public DbSet<Mascota> Mascotas {get; set;}
        public DbSet<Cita> Citas {get; set;} 
        public DbSet<HistoriaClinica> HistoriaClinicas {get; set;}
        public DbSet<Usuario> Usuarios {get; set;}
        public DbSet<Admin> Admins {get; set;}

        // Config
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if(!options.IsConfigured) {
                options.UseSqlServer("Data Source = (localdb \\MSSQLLocalDB; Initial Catalog = VetPet)");
            }
        }

        // Builder
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Persona>()
                .HasIndex(p => p.cedula)
                .IsUnique();
        }
    }

}
