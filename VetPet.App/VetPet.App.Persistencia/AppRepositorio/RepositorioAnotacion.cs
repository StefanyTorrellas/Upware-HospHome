using System.Collections.Generic;
using System.Linq;
using VetPet.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace VetPet.App.Persistencia
{
    public class RepositorioAnotacion : IRepositorioAnotacion
    {
        
        private readonly Context _context;
        public RepositorioAnotacion(Context context)
        {
            this._context = context;
        }

        public Anotacion addAnotacion(Anotacion anotacion)
        {
            Anotacion anotacionNueva = _context.Add(anotacion).Entity;
            _context.SaveChanges();
            return anotacionNueva;

        }

        public Anotacion editAnotacion(Anotacion anotacion)
        {
            Anotacion anotacionEncontrada = _context.Anotaciones.FirstOrDefault(a => a.id == anotacion.id);
            if(anotacionEncontrada!= null){
                anotacionEncontrada.descripcion = anotacion.descripcion;
                anotacionEncontrada.medicamento = anotacion.medicamento;
                anotacionEncontrada.veterinario = anotacion.veterinario;
                anotacionEncontrada.mascota = anotacion.mascota;
                //anotacionEncontrada.fecha = anotacion.fecha;
            }
            return anotacionEncontrada;
        }

        public IEnumerable<Anotacion> getAllAnotaciones()
        {
            return _context.Anotaciones.Include("veterinario").Include("mascota").Include("medicamento");
        }

        public Anotacion getAnotacion(int id)
        {
            return _context.Anotaciones.Include("veterinario").Include("mascota").Include("medicamento").FirstOrDefault(a => a.id == id);
        }

        public void removeAnotacion(Anotacion anotacion)
        {
            Anotacion anotacionEncontrada = _context.Anotaciones.FirstOrDefault(a => a.id == anotacion.id);
            if(anotacionEncontrada != null){
                _context.Anotaciones.Remove(anotacionEncontrada);
                _context.SaveChanges();
            }
        }
    }
}
