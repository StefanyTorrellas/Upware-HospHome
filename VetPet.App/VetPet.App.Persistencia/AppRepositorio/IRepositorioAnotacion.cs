using System.Collections.Generic;
using VetPet.App.Dominio;

namespace VetPet.App.Persistencia
{
    public interface IRepositorioAnotacion
    {
        IEnumerable<Anotacion> getAllAnotaciones();
        Anotacion addAnotacion(Anotacion anotacion);
        Anotacion editAnotacion(Anotacion anotacion);
        Anotacion getAnotacion(int id);
        void removeAnotacion(int id);
    }
}
