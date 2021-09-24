using System.Collections.Generic;
using System.Linq;
using VetPet.App.Dominio;

namespace VetPet.App.Persistencia
{
    public class RepositorioMascota : IRepositorioVeterinario
    {
        // Contexto
        private readonly Context _context;
        public RepositorioMascota(Context context)
        {
            this._context = context;
        }

        // Obtener todas las mascotas
        public IEnumerable<Veterinario> getAllVeterinarios()
        {
            return _context.Veterinarios;
        }

        // Añadir veterinariveterinario
        public Veterinario addMascota(Veterinario veterinariveterinario
        {
            Veterinario veterinarioNuevo = _context.Add(veterinaio;
            return veterinarioNueva;
        }
        
        // Editar veterinariveterinario
        public Veterinario editMascota(Veterinario veterinariveterinario
        {
            Veterinario mascotaEdicion = _context.Veterinarios.FirstOrDefault(m => m.id == veterinariveterinario
                if(mascotaEdicion != null) {
                    mascotaEdicion.id = veterinariveterinario
                    mascotaEdicion.tipo = veterinariveterinario
                    mascotaEdicion.name = veterinariveterinario
                    mascotaEdicion.edad = veterinariveterinario
                    mascotaEdicion.descripcion = veterinariveterinarioipcion;
                    mascotaEdicion.propietario_id = veterinariveterinarioetario_id;
                    _context.SaveChanges();
                }
            return mascotaEdicion;
        }

        // Obtener una veterinariveterinario
        public Veterinario getMascota(int id)
        {
            return _context.Veterinarios.FirstOrDefault(m => m.id == id);
        }

        // Eliminar veterinariveterinario
        public void removeMascota(int id)
        {
            Veterinario mascotaEliminar = _context.Veterinarios.FirstOrDefault(m => m.id == id);
            if (mascotaEliminar != null) {
                _context.Veterinarios.Remove(mascotaEliminar);
                _context.SaveChanges();
            }
        }
    }
}
