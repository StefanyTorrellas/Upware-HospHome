using System.Collections.Generic;
using System.Linq;
using VetPet.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace VetPet.App.Persistencia
{
    public class RepositorioAnotacion : IRepositorioAnotacion
    {
        // Contexto
        private readonly Context _context;
        public RepositorioAnotacion(Context context)
        {
            this._context = context;
        }

        // Obtener todas las anotaciones
        public IEnumerable<Anotacion> getAllAnotaciones()
        {
            return _context.Anotaciones.Include("mascota").Include("veterinario");
        }

        // Añadir anotacion
        public Anotacion addAnotacion(Anotacion anotacion)
        {
            Anotacion anotacionNueva = _context.Add(anotacion).Entity;
            _context.SaveChanges();
            return anotacionNueva;
        }
        
        // Editar anotacion
        public Anotacion editAnotacion(Anotacion anotacion)
        {
            Anotacion anotacionEdicion = _context.Anotaciones.FirstOrDefault(m => m.id == anotacion.id);
                if(anotacionEdicion != null) {
                    anotacionEdicion.id = anotacion.id;
                    anotacionEdicion.fecha = anotacion.fecha;
                    anotacionEdicion.mascota = anotacion.mascota;
                    anotacionEdicion.veterinario = anotacion.veterinario;
                    anotacionEdicion.descripcion = anotacion.descripcion;
                    anotacionEdicion.medicamento = anotacion.medicamento;
                    _context.SaveChanges();
                }
            return anotacionEdicion;
        }

        // Obtener una anotacion
        public Anotacion getAnotacion(int id)
        {
            return _context.Anotaciones.Include("mascota").Include("veterinario").FirstOrDefault(m => m.id == id);
        }

        // Eliminar anotacion
        public void removeAnotacion(int id)
        {
            Anotacion anotacionEliminar = _context.Anotaciones.FirstOrDefault(m => m.id == id);
            if (anotacionEliminar != null) {
                _context.Anotaciones.Remove(anotacionEliminar);
                _context.SaveChanges();
            }
        }
    }
}
