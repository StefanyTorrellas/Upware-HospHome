using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VetPet.App.Dominio;
using VetPet.App.Persistencia;

namespace VetPet.App.Frontend
{
    public class AddAnotacionesModel : PageModel
    {
        private readonly IRepositorioAnotacion repositorioAnotacion;
        private readonly IRepositorioMascota repositorioMascota;
        private readonly IRepositorioPropietario repositorioPropietario;
        private readonly IRepositorioVeterinario repositorioVeterinario;
        private readonly IRepositorioHistoria repositorioHistoria;

        public IEnumerable<SelectListItem> propietarios {get; set;}
        public IEnumerable<SelectListItem> mascotas {get; set;}
        public IEnumerable<SelectListItem> veterinarios {get; set;}

        public Anotacion anotacion {get; set;}

        public int cedulaPropietario {get; set;}
        public int cedulaVeterinario {get; set;}

        public AddAnotacionesModel(IRepositorioAnotacion repositorioAnotacion, IRepositorioMascota repositorioMascota, IRepositorioVeterinario repositorioVeterinario, IRepositorioHistoria repositorioHistoria, IRepositorioPropietario repositorioPropietario) {
            this.repositorioAnotacion = repositorioAnotacion;
            this.repositorioMascota = repositorioMascota;
            this.repositorioPropietario = repositorioPropietario;
            this.repositorioVeterinario = repositorioVeterinario;
            this.repositorioHistoria = repositorioHistoria;
        }

        public void OnGet()
        {
            propietarios = repositorioPropietario.getAllPropietarios().Select(
                m => new SelectListItem {
                    Value = Convert.ToString(m.cedula),
                    Text = m.nombre +" "+m.apellido
                }
            );
        
        
            mascotas = repositorioMascota.getAllMascotas().Select(
                m => new SelectListItem {
                    Value = Convert.ToString(m.id),
                    Text = m.nombre
                }
            );
            veterinarios = repositorioVeterinario.getAllVeterinarios().Select(
                m => new SelectListItem {
                    Value = Convert.ToString(m.cedula),
                    Text = m.nombre
                }
            );

            anotacion = new Anotacion();
        }

        public IActionResult OnPost (Anotacion anotacion, int cedulaPropietario, int cedulaVeterinario) {
            if (ModelState.IsValid) {
                Mascota mascota = repositorioMascota.getMascotaP(cedulaPropietario);
                Veterinario veterinario = repositorioVeterinario.getVeterinario(cedulaVeterinario);

                Anotacion anotacionNueva = new Anotacion() {
                    fecha = anotacion.fecha,
                    mascota = mascota,
                    veterinario = veterinario,
                    descripcion = anotacion.descripcion,
                    medicamento = anotacion.medicamento
                };

                Historia historia = repositorioHistoria.historiaP(mascota);

                if (historia == null) {
                    historia = new Historia() {
                        descripcion = "Fecha: "+DateTime.Now+" Mascota "+mascota.nombre+ "Mascota "+mascota.propietario.nombre+" "+mascota.propietario.apellido,
                        anotaciones = new List<Anotacion>{anotacionNueva}
                    };
                    repositorioHistoria.addHistoria(historia);
                }
                else {
                    List<Anotacion> listAnotaciones = historia.anotaciones;
                    listAnotaciones.Add(anotacionNueva);
                    historia.anotaciones = listAnotaciones;
                    repositorioHistoria.editHistoria(historia);
                }
                return RedirectToPage("/Admin/Anotaciones/ListAnotaciones");
            }
            else {
                return Page();
            }
        }
    }
}
