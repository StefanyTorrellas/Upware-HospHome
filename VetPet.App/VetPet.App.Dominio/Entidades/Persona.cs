using System;

namespace VetPet.App.Dominio
{
    public class Persona 
    {
        public int id {get; set;}
        public int cedula {get; set;}
        public string nombre {get; set;}
	      public string apellido {get; set;}
        public int edad {get; set;}
        public Genero genero {get; set;}
    }
}
