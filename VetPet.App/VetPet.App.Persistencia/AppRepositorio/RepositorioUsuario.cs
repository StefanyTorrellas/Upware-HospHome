using System.Collections.Generic;
using System.Linq;
using VetPet.App.Dominio;

namespace VetPet.App.Persistencia
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        // Contexto
        private readonly Context _context;
        public RepositorioUsuario(Context context)
        {
            this._context = context;
        }

        // Obtener todas las mascotas
        public IEnumerable<Usuario> getAllUsuarios()
        {
            return _context.Usuarios;
        }

        // Añadir usuario
        public Usuario addUsuario(Usuario usuario)
        {
            Usuario usuarioNuevo = _context.Add(usuario).Entity;
            return usuarioNuevo;
        }
        
        // Editar usuario
        public Usuario editUsuario(Usuario usuario)
        {
            Usuario usuarioEdicion = _context.Usuarios.FirstOrDefault(m => m.id == usuario.id);
                if(usuarioEdicion != null) {
                    usuarioEdicion.id = usuario.id;
		    usuarioEdicion.username = usuario.username;
                    usuarioEdicion.password = usuario.password;
                    _context.SaveChanges();
                }
            return usuarioEdicion;
        }

        // Obtener una usuario
        public Usuario getUsuario(int id)
        { 
            return _context.Usuarios.FirstOrDefault(m => m.id == id);
        }

        // Eliminar usuario
        public void removeUsuario(int id)
        {
            Usuario usuarioEliminar = _context.Usuarios.FirstOrDefault(m => m.id == id);
            if (usuarioEliminar != null) {
                _context.Usuarios.Remove(usuarioEliminar);
                _context.SaveChanges();
            }
        }
    }
}
