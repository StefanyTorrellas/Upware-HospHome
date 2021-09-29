using System.Collections.Generic;
using System.Linq;
using VetPet.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace VetPet.App.Persistencia
{
    public class RepositorioMascota : IRepositorioMascota
    {
        // Contexto
        private readonly Context _context;
        public RepositorioMascota(Context context)
        {
            this._context = context;
        }

        // Obtener todas las mascotas
        public IEnumerable<Mascota> getAllMascotas()
        {
            return _context.Mascotas.Include("propietario");
        }

        // Añadir mascota
        public Mascota addMascota(Mascota mascota)
        {
            Mascota mascotaNueva = _context.Add(mascota).Entity;
            _context.SaveChanges();
            return mascotaNueva;
        }
        
        // Editar mascota
        public Mascota editMascota(Mascota mascota)
        {
            Mascota mascotaEdicion = _context.Mascotas.FirstOrDefault(m => m.id == mascota.id);
                if(mascotaEdicion != null) {
                    mascotaEdicion.id = mascota.id;
                    mascotaEdicion.tipo = mascota.tipo;
                    mascotaEdicion.nombre = mascota.nombre;
                    mascotaEdicion.edad = mascota.edad;
                    mascotaEdicion.descripcion = mascota.descripcion;
                    mascotaEdicion.propietario = mascota.propietario;
                    _context.SaveChanges();
                }
            return mascotaEdicion;
        }

        // Obtener una mascota
        public Mascota getMascota(int id)
        {
            return _context.Mascotas.Include("propietario").FirstOrDefault(m => m.id == id);
        }

        // Eliminar mascota
        public void removeMascota(int id)
        {
            Mascota mascotaEliminar = _context.Mascotas.FirstOrDefault(m => m.id == id);
            if (mascotaEliminar != null) {
                _context.Mascotas.Remove(mascotaEliminar);
                _context.SaveChanges();
            }
        }
    }
}
