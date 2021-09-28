using System.Collections.Generic;
using System.Linq;
using VetPet.App.Dominio;

namespace VetPet.App.Persistencia
{
    public class RepositorioVeterinario : IRepositorioVeterinario 
    {
        // Contexto
        private readonly Context _context;
        public RepositorioVeterinario(Context context) 
        {
            this._context = context;
        }

        // Obtener todas los veterinarios
        public IEnumerable<Veterinario> getAllVeterinarios()
        {
            return _context.Veterinarios;
        }

        // Añadir veterinario
        public Veterinario addVeterinario(Veterinario veterinario)
        {
            Veterinario veterinarioNuevo = _context.Add(veterinario).Entity;
            return veterinarioNuevo;
        }

        // Editar Veterinario
        public Veterinario editVeterinario(Veterinario veterinario)
        {
            Veterinario veterinarioEdicion = _context.Veterinarios.FirstOrDefault(v => v.id == veterinario.id);
                if(veterinarioEdicion != null) {
                    veterinarioEdicion.cedula = veterinario.cedula;
                    veterinarioEdicion.nombre = veterinario.nombre;
                    veterinarioEdicion.edad = veterinario.edad;
                    veterinarioEdicion.genero = veterinario.genero;
                    veterinarioEdicion.horario_entrada = veterinario.horario_entrada;
                    veterinarioEdicion.horario_salida = veterinario.horario_salida;
                    _context.SaveChanges();
                }
            return veterinarioEdicion;
        }
 
        // Obtener una Veterinario
        public Veterinario getVeterinario(int cedula)
        {
            return _context.Veterinarios.FirstOrDefault(p => p.cedula == cedula);
        }

        // Eliminar veterinario
        public void removeVeterinario(int cedula)
        {
            Veterinario veterinarioEliminar = _context.Veterinarios.FirstOrDefault(v => v.cedula == cedula);
            if (veterinarioEliminar != null) {
                _context.Veterinarios.Remove(veterinarioEliminar);
                _context.SaveChanges();
            }
        }
    }
}
