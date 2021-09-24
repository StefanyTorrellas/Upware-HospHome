using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VetPet.App.Frontend.Pages
{
    public class RemoveVeterinarioModel : PageModel
    {

        private readonly IRepositorioVeterinario repositorioVeterinario;

        public Veterinario veterinario {get; set;}

        public RemoveVeterinarioModel(IRepositorioVeterinario repositorioVeterinario) {
            this.repositorioVeterinario = repositorioVeterinario;
        }

        public void OnGet()
        {
            veterinario = repositorioVeterinario.getVeterinario(cedula);
        }

        public IActionResult OnPost(int cedula) {
            repositorioVeterinario.removeVeterinario(cedula);
            return RedirectToPage("/admin/veterinario/list");
        }
    }
}
