using System;
using VetPet.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace VetPet.App.Persistencia
{
    public class Context : DbContext
    {
        public DbSet<Persona> Personas {get; set;}
        public DbSet<Propietario> Propietarios {get; set;}
        public DbSet<Mascota> Mascotas {get; set;}   
    }
}
