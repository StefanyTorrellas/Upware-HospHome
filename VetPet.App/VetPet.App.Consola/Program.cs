using System;
using VetPet.App.Dominio;
using VetPet.App.Persistencia;

namespace VetPet.App.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepositorioVeterinario repositorioVeterinario = new RepositorioVeterinario(new Context());
        }
    }
}
