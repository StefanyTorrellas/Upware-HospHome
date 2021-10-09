using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetPet.App.Dominio
{
    public class Propietario:Persona
    {
        public List<Mascota> mascotas {get;set;}
        public string ciudad {get; set;}
        public string direccion {get; set;}
    }
}
