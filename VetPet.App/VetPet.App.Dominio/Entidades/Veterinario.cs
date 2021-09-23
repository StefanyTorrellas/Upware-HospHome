namespace VetPet.App.Dominio
{
    public class Veterinario : Persona
    {
        public string tarjeta_profesional {get; set;} 
        public string horario_entrada {get; set;}
        public string horario_salida {get; set;}
        public bool disponible {get; set;}
    }
}
