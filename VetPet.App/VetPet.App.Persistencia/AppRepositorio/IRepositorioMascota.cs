using System.Collections.Generic;
using VetPet.App.Dominio;

namespace VetPet.App.Persistencia
{
    public interface IRepositorioMascota
    {
        IEnumerable<Mascota> getAllMascotas();
        Mascota addMascota(Mascota mascota);
        Mascota editMascota(Mascota mascota);
        Mascota getMascota(int id);
        Mascota getMascotaP(int cedula);
        void removeMascota(int id);
        void removeMascotaP(int cedula);
    }
}
