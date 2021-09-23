using System;

namespace VetPet.App.Dominio
{
    public class Mascota
    {
        public int id {get; set;} 
        public Tipo tipo {get; set;}
        public string name {get; set;}
        public int edad {get; set;}
        public string descripcion {get; set;}
        public int propietario_id {get; set;}
    }
}
