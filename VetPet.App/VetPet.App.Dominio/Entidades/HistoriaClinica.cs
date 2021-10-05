using System;

namespace VetPet.App.Dominio {

    public class HistoriaClinica
    {
        public int id {get; set;} 
        public Mascota mascota {get; set;}
        public string anotaciones {get; set;}
        public Cita cita {get; set;}
        public string medicamento {get; set;}
    }
}
