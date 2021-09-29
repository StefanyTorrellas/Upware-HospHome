using System.Collections.Generic;
using VetPet.App.Dominio;

namespace VetPet.App.Persistencia
{
    public interface IRepositorioCita
    {
        IEnumerable<Cita> getAllCitas();
        Cita addCita(Cita cita);
        Cita editCita(Cita cita);
        Cita getCita(int id);
        void removeCita(int id);
    }
}
