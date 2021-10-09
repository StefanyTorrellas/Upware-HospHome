using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetPet.App.Dominio {
    public class Anotacion {
        [Key]
        public int id {get; set;}
        [Required(ErrorMessage = "La fecha es obligatoria."),DataType(DataType.DateTime), Range(typeof(DateTime), "1/1/2021", "2025/12/31", ErrorMessage ="El valor {0} debe estar {1} y {2}")]
        public DateTime fecha {get; set;}
        public Mascota mascota {get; set;}
        public Veterinario veterinario {get; set;}
        public string descripcion {get; set;}
        public int medicamento {get; set;}
    }
}