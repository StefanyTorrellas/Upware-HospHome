using System.Collections.Generic;
using System.Linq;
using VetPet.App.Dominio;

namespace VetPet.App.Persistencia
{
    public class RepositorioMascota : IRepositorioMascota
    {
        // Contexto
        private readonly Context _context;
        public RepositorioMascota(Context context)
        {
            this.context = context;
        }

        // Obtener todas las mascotas
        public IEnumerable<Mascota> getAllMascotas()
        {
            return _context.Mascotas;
        }

        // Añadir mascota
        public Mascota addMascota(Mascota mascota)
        {
            Mascota mascotaNueva = _context.Add(Mascota).Entity;
            return mascotaNueva;
        }
        
        // Editar mascota
        public Mascota editMascota(Mascota mascota)
        {
            Mascota mascotaEdicion = _context.Mascotas.FirstOrDefault(m => m.id == mascota.id)
                if(mascotaEdicion != null) {
                    mascotaEdicion.intd = mascota.id;
                    mascotaEdicion.tipo = mascota.tipo;
                    mascotaEdicion.name = mascota.name;
                    mascotaEdicion.edad = mascota.edad;
                    mascotaEdicion.descripcion = mascota.descripcion;
                    mascotaEdicion.propietario_id = mascota.propietario_id;
                    _context.SaveChanges();
                }
            return mascotaEdicion;
        }

        // Obtener una mascota
        public Mascota getMascota(int id)
        {
            return _context.Mascotas.FirstOrDefault(m => m.id == id);
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
