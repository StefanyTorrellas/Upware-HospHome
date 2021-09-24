using System.Collections.Generic;
using VetPet.App.Dominio;

namespace VetPet.App.Persistencia
{
    public interface IRepositorioPropietario
    {
        IEnumerable<Propietario> getAllPropietarios();
        Propietario addPropietario(Propietario propietario);
        Propietario editPropietario(Propietario propietario);
        Propietario getPropietario(int cedula);
        void removePropietario(int cedula);
    }
}
