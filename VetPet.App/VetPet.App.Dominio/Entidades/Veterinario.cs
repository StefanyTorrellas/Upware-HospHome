using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetPet.App.Dominio.Entidades
{
    public class Veterinario : Persona
    {
        public DateTime horario_entrada {get; set;}
        public DateTime horario_salida {get; set;}
    }
}
