using System;
using System.ComponentModel.DataAnnotations;

namespace VetPet.App.Dominio
{
    public class Veterinario : Persona
    {
        [Required(ErrorMessage = "La hora de entrada es obligatoria."),DataType(DataType.Time)]
        public DateTime horario_entrada {get; set;}
        [Required(ErrorMessage = "La hora de salida es obligatoria."),DataType(DataType.Time)]
        public DateTime horario_salida {get; set;}
    }
}
