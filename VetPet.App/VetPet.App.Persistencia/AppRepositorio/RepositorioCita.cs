using System;
using System.Collections.Generic;
using System.Linq;
using VetPet.App.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace VetPet.App.Persistencia
{
    public class RepositorioCita : IRepositorioCita 
    {
        // Contexto
        private readonly Context _context;
        public RepositorioCita(Context context) 
        {
            this._context = context;
        }

        // Obtener todas las citas
        public IEnumerable<Cita> getAllCitas()
        {
            return _context.Citas.Include("veterinario").Include("mascota");
        }

        // Añadir cita
        public Cita addCita(Cita cita)
        {
            Cita citaCruzada = _context.Citas.FirstOrDefault(
                c => c.veterinario.cedula == cita.veterinario.cedula &&
                cita.dia == c.dia &&
                cita.hora >= c.hora &&
                cita.hora < c.hora.AddMinutes(30)
            );

            Cita citaEspacio = _context.Citas.FirstOrDefault(
                c => c.dia == cita.dia &&
                cita.hora >= c.hora &&
                cita.hora < c.hora.AddMinutes(30)
            );

            Cita citaMascota = _context.Citas.FirstOrDefault(
                c => c.mascota.id == cita.mascota.id &&
                cita.dia == c.dia &&
                cita.hora >= c.hora &&
                cita.hora < c.hora.AddMinutes(30)
            );

            if(citaEspacio == null && citaCruzada == null && citaMascota == null) {
                Cita citaNueva = _context.Add(cita).Entity;
                _context.SaveChanges();
                return citaNueva;
            }
            else {
                return null;
            }
        }
        
        // Obtener una cita
        public Cita getCita(int id)
        {
            return _context.Citas.Include("veterinario").Include("mascota").FirstOrDefault(c => c.id == id);
        }

    }
}
