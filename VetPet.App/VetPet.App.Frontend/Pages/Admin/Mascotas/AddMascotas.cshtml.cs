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
    public class AddMascotasModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        private readonly IRepositorioPropietario repositorioPropietario;
        public Mascota mascota {get; set;}

        public IEnumerable<SelectListItem>propietarios {get; set;}
        public int cedulaPropietario {get; set;}

        public AddMascotasModel(IRepositorioMascota repositorioMascota, IRepositorioPropietario repositorioPropietario) {
            this.repositorioMascota = repositorioMascota;
            this.repositorioPropietario = repositorioPropietario;
        }

        public void OnGet()
        {
            mascota = new Mascota();
            propietarios = repositorioPropietario.getAllPropietarios().Select(
                    a => new SelectListItem
                    {
                        Value = Convert.ToString(a.cedula),
                        Text = a.nombre
                    }
                    ).ToList();
        }

        public IActionResult OnPost(Mascota mascota, int cedulaPropietario) {
	        if (ModelState.IsValid)
            {
                Propietario propietario = repositorioPropietario.getPropietario(cedulaPropietario);
            	try {
                    repositorioMascota.addMascota(mascota);
                    mascota.propietario = propietario;
                    //repositorioMascota.editMascota(mascota);
                    return Redirect("/admin/mascotas/list");
                }
                catch (Exception e){
                    Console.WriteLine(e);
                    return RedirectToPage("/Error");
                }
            }
    	    else {
		        return Page();
            }
        }
    }
}
