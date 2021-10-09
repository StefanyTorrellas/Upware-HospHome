using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VetPet.App.Dominio {

    public class Historia
    {
        [Key]
        public int id {get; set;} 
        public List<Anotacion> anotaciones {get; set;}
        public string descripcion {get; set;}
    }
}
