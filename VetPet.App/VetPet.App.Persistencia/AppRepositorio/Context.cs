using System;
using VetPet.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace VetPet.App.Persistencia
{
    public class Context : DbContext
    {
        public DbSet<Persona> Personas <get; set;>
    }
}
