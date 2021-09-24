using System;
using VetPet.App.Dominio;
using VetPet.App.Persistencia;

namespace VetPet.App.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepositorioPropietario repositorioPropietario = new RepositorioPropietario(new Context());
        }
    }
}
