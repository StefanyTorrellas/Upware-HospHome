using System.Collections.Generic;
using System.Linq;
using VetPet.App.Dominio;

namespace VetPet.App.Persistencia
{
    public class RepositorioPropietario : IRepositorioPropietario 
    {
        // Contexto
        private readonly Context _context;
        public RepositorioPropietario(Context context) 
        {
            this._context = context;
        }

        // Obtener todas los propietarios
        public IEnumerable<Propietario> getAllPropietarios()
        {
            return _context.Propietarios;
        }

        // Añadir propietario
        public Propietario addPropietario(Propietario propietario)
        {
            Propietario propietarioNuevo = _context.Add(propietario).Entity;
            return propietarioNuevo;
        }
        
        // Editar propietario
        public Propietario editPropietario(Propietario propietario)
        {
            Propietario propietarioEdicion = _context.Propietarios.FirstOrDefault(p => p.id == propietario.id);
                if(propietarioEdicion != null) {
                    propietarioEdicion.cedula = propietario.cedula;
                    propietarioEdicion.nombre = propietario.nombre;
                    propietarioEdicion.edad = propietario.edad;
                    propietarioEdicion.genero = propietario.genero;
                    propietarioEdicion.ciudad = propietario.ciudad;
                    propietarioEdicion.direccion = propietario.direccion;
                    _context.SaveChanges();
                }
            return propietarioEdicion;
        }

        // Obtener una propietario
        public Propietario getPropietario(int cedula)
        {
            return _context.Propietarios.FirstOrDefault(p => p.cedula == cedula);
        }

        // Eliminar propietario
        public void removePropietario(int cedula)
        {
            Propietario propietarioEliminar = _context.Propietarios.FirstOrDefault(p => p.cedula == cedula);
            if (propietarioEliminar != null) {
                _context.Propietarios.Remove(propietarioEliminar);
                _context.SaveChanges();
            }
        }
    }
}
