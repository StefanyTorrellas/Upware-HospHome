using System.Collections.Generic;
using VetPet.App.Dominio;

namespace VetPet.App.Persistencia
{
    public interface IRepositorioUsuario
    {
        IEnumerable<Usuario> getAllUsuarios();
        Usuario addUsuario(Usuario usuario);
        Usuario editUsuario(Usuario usuario);
        Usuario getUsuario(int id);
        void removeUsuario(int id);
    }
}
