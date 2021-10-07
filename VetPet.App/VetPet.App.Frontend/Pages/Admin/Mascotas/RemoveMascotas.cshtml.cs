using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VetPet.App.Dominio;
using VetPet.App.Persistencia;

namespace VetPet.App.Frontend
{
    public class RemoveMascotasModel : PageModel
    {
	      private readonly IRepositorioMascota repositorioMascota;
	      public Mascota mascota {get; set;}

        public RemoveMascotasModel (IRepositorioMascota repositorioMascota) {
            this.repositorioMascota = repositorioMascota;	
        }

        public void OnGet(int id)
        {
            mascota = repositorioMascota.getMascota(id);
        }

        public IActionResult OnPost(Mascota mascota) {
            if (ModelState.IsValid) {
                try {
                    repositorioMascota.removeMascota(mascota.id);
                    return Redirect("/admin/mascotas/list");
                }
                catch (Exception e) {
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
