using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetPet.App.Dominio {

    public class Cita
    {
        [Key]
        public int id {get; set;}
        public Mascota mascota {get; set;}
        public Veterinario veterinario { get; set; }
        [Required,DataType(DataType.Date),Range(typeof(DateTime), "1/1/2021", "2025/12/31",
        ErrorMessage = "El valor {0} debe estar {1} y {2}")]
        public DateTime dia { get; set; }
        [Required,DataType(DataType.Time)]
        public DateTime hora { get; set; }
        public string descripcion { get; set; }
    }
}
