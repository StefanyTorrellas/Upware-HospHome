using System.Collections.Generic;
using System.Linq;
using VetPet.App.Dominio;
using Microsoft.EntityFrameworkCore;

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
            return _context.Citas;
        }

        // Añadir cita
        public Cita addCita(Cita cita)
        {
            Cita citaNueva = _context.Add(cita).Entity;
            _context.SaveChanges();
            return citaNueva;
        }
        
        // Editar cita
        public Cita editCita(Cita cita)
        {
           Cita citaEdicion = _context.Citas.FirstOrDefault(c => c.id == cita.id);
                if(citaEdicion != null) {
                    citaEdicion.id = cita.id;
                    citaEdicion.fecha =  cita.fecha;
                    citaEdicion.hora = cita.hora;
                    citaEdicion.mascota = cita.mascota;
                    _context.SaveChanges();
                }
            return citaEdicion;  
            }

        // Obtener una cita
        public Cita getCita(int id)
        {
            return _context.Citas.FirstOrDefault(c => c.id == id);
        }

        // Eliminar cita
        public void removeCita(int id)
        {
            Cita citaEliminar = _context.Citas.FirstOrDefault(c => c.id == id);
            if (citaEliminar != null) {
                _context.Citas.Remove(citaEliminar);
                _context.SaveChanges();
            }
        }
    }
}
