using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VetPet.App.Frontend.Pages
{
    public class EditVeterinarioModel : PageModel
    {

        private readonly IRepositorioVeterinario repositorioVeterinario;
        public Veterinario veterinario{get; set;}
        public EditVeterinarioModel(IRepositorioVeterinario repositorioVeterinario){
            this repositorioVeterinario = repositorioVeterinario;
        }

        public void OnGet()
        {
            veterinario = repositorioVeterinario.getVeterinario(cedula);
        }

        public IActionResult OnPost (Veterinario veterinario) {
            try {
                repositorioVeterinario.editVeterinario(veterinario);
                return RedirectToPage("/admin/veterinario/list");
            }
            catch {
                return RedirectToPage("/Error");
            }
        }
    }
}
