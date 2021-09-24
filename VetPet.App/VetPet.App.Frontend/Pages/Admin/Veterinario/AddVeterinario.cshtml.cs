using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VetPet.Add.Dominio;
using VetPet.Add.Persistencia;

namespace VetPet.App.Frontend.Pages
{
    public class AddVeterinarioModel : PageModel
    {

        private readonly IRepositorioVeterinario repositorioVeterinario;
        public Veterinario veterinario{get; set;}
        public AddVeterinarioModel(IRepositorioVeterinario repositorioVeterinario) {
            this.repositorioVeterinario = repositorioVeterinario;
        }

        public void OnGet()
        {
            veterinario = new Veterinario();

        }

        public IActionResult OnPost(Veterinario veterinario) {
            try {
                repositorioVeterinario.addVeterinario(veterinario);
                return RedirectToPage("/admin/veterinario/list");
            }
            catch {
                return RedirectToPage("/Error");
            }
        }
    }
}
