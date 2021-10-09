using System.Collections.Generic;
using System.Linq;
using VetPet.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace VetPet.App.Persistencia
{
    public class RepositorioHistoria : IRepositorioHistoria 
    {
        // Contexto
        private readonly Context _context;
        public RepositorioHistoria(Context context) 
        {
            this._context = context;
        }

        // Obtener todas las citas
        public IEnumerable<Historia> getAllHistorias()
        {
            return _context.Historias.Include("anotacion").Include("anotacion.mascota");
        }

        // Añadir historia
        public Historia addHistoria(Historia historia)
        {
            Historia historiaNueva = _context.Add(historia).Entity;
            _context.SaveChanges();
            return historiaNueva;
        }
        
        // Editar historia
        public Historia editHistoria(Historia historia)
        {
           Historia historiaEdicion = _context.Historias.FirstOrDefault(c => c.id == historia.id);
                if(historiaEdicion != null) {
                    historiaEdicion.id = historia.id;
                    historiaEdicion.anotaciones =  historia.anotaciones;
                    historiaEdicion.descripcion = historia.descripcion;
                    _context.SaveChanges();
                }
            return historiaEdicion;  
            }

        // Obtener una historia
        public Historia getHistoria(int id)
        {
            return _context.Historias.FirstOrDefault(c => c.id == id);
        }

        // Eliminar historia
        public void removeHistoria(int id)
        {
            Historia historiaEliminar = _context.Historias.FirstOrDefault(c => c.id == id);
            if (historiaEliminar != null) {
                _context.Historias.Remove(historiaEliminar);
                _context.SaveChanges();
            }
        }

        public Historia historiaP(Mascota mascota) {
            return _context.Historias.FirstOrDefault(h => h.anotaciones.All(a => a.mascota.id == mascota.id));
        }
    }
}
