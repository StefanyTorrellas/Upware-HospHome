using System.Collections.Generic;
using System.Linq;
using VetPet.App.Dominio;

namespace VetPet.App.Persistencia
{
    public class RepositorioAdmin : IRepositorioAdmin
    {
        // Contexto
        private readonly Context _context;
        public RepositorioAdmin(Context context)
        {
            this._context = context;
        }

        // Obtener todas las mascotas
        public IEnumerable<Admin> getAllAdmins()
        {
            return _context.Admins;
        }

        // Añadir admin
        public Admin addAdmin(Admin admin)
        {
            Admin adminNuevo = _context.Add(admin).Entity;
            return adminNuevo;
        }
        
        // Editar admin
        public Admin editAdmin(Admin admin)
        {
            Admin adminEdicion = _context.Admins.FirstOrDefault(m => m.id == admin.id);
                if(adminEdicion != null) {
                    adminEdicion.id = admin.id;
                    _context.SaveChanges();
                }
            return adminEdicion;
        }

        // Obtener una admin
        public Admin getAdmin(int id)
        { 
            return _context.Admins.FirstOrDefault(m => m.id == id);
        }

        // Eliminar admin
        public void removeAdmin(int id)
        {
            Admin adminEliminar = _context.Admins.FirstOrDefault(m => m.id == id);
            if (adminEliminar != null) {
                _context.Admins.Remove(adminEliminar);
                _context.SaveChanges();
            }
        }
    }
}
