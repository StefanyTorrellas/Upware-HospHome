using System;

namespace VetPet.App.Dominio {

    public class HistoriaClinica
    {
        public int id {get; set;} 
        public int mascota_id {get; set;}
        public string anotaciones {get; set;}
        public string cita_id {get; set;}
        public int medicamento {get; set;}
    }
}
