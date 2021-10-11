using System.Collections.Generic;
using VetPet.App.Dominio;

namespace VetPet.App.Persistencia
{
    public interface IRepositorioCita
    {
        IEnumerable<Cita> getAllCitas();
        Cita getCita(int Id);
        Cita addCita(Cita cita);
    }
}