using System.Collections.Generic;
using VetPet.App.Dominio;

namespace VetPet.App.Persistencia
{
    public interface IRepositorioCita
    {
        IEnumerable<Cita> getAllCitas();
        Cita addCita(Cita veterinario);
        Cita editCita(Cita veterinario);
        Cita getCita(int id);
        void removeCita(int id);
    }
}
