using System;
using System.Collections.Generic;
using System.Linq;
using VetPet.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace VetPet.App.Persistencia{
    public class RepositorioHistoria : IRepositorioHistoria
    {
        private readonly Context _context;
        public RepositorioHistoria(Context context)
        {
            this._context = context;
        }

        public Historia addHistoria(Historia historia)
        {
            Historia historiaNueva = _context.Add(historia).Entity;
            _context.SaveChanges();
            return historiaNueva;
        }

        public Historia editHistoria(Historia historia)
        {
            Historia historiaEncontrada = _context.Historias.FirstOrDefault(h => h.id == historia.id);
            if(historiaEncontrada != null){
                historiaEncontrada.anotaciones = historia.anotaciones;
                historiaEncontrada.descripcion = historia.descripcion;
                _context.SaveChanges();
            }
            return historiaEncontrada;
        }

        public IEnumerable<Historia> getAllHistorias()
        {
            return _context.Historias;
        }

        public Historia getHistoria(int id)
        {
            return _context.Historias.FirstOrDefault(h => h.id == id);
        }

        public Historia getHistoriaByVeterinario(Veterinario veterinario)
        {
            return _context.Historias.Include("anotaciones").FirstOrDefault(h => h.anotaciones.All(a => a.veterinario.id == veterinario.id));

        }

        public Historia getHistoriaByMascota(Mascota mascota)
        {
            return _context.Historias.Include("anotaciones").FirstOrDefault(h => h.anotaciones.All(a=>a.mascota.id == mascota.id));
        }

        public void RemoveHistoria(int id)
        {
            Historia historiaEncontrada = _context.Historias.FirstOrDefault(h => h.id == id);
            if(historiaEncontrada != null){
                _context.Historias.Remove(historiaEncontrada);
                _context.SaveChanges();
            }
        }
    }
}
