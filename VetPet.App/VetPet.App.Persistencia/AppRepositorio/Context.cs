using System;
using VetPet.App.Dominio;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace VetPet.App.Persistencia
{
    public class Context : DbContext
    {
        public DbSet<Persona> Personas {get; set;}
        public DbSet<Propietario> Propietarios {get; set;}
	public DbSet<Veterinario> Veterinarios {get; set;}
        public DbSet<Mascota> Mascotas {get; set;}
        public DbSet<Cita> Citas{get; set;}
        public DbSet<HistoriaClinica> HistoriasClinicas {get; set;}
        public DbSet<Usuario> Usuarios {get; set;}
        public DbSet<Admin> Admins {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if(!options.IsConfigured) {
/*
                var connectionString = "Server=localhost; User=mysql; Password=1234; Database=vetpet";
		            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
*/
<<<<<<< HEAD
                options.UseSqlServer("Data Source = (localdb \\MSSQLLocalDB; Initial Catalog = VetPet;)");
=======
                options.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = VetPet)");
>>>>>>> 4ce66f8e07b4a0cadf01b80e90fa3ab91fc84385
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Persona>()
                .HasIndex(u => u.cedula)
                .IsUnique();
        }
    }
}
