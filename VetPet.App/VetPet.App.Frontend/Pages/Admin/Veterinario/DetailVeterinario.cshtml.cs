using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VetPet.App.Dominio;
using VetPet.App.Persistencia;

namespace VetPet.App.Frontend.Pages
{
    public class DetailVeterinarioModel : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinario;
        public Veterinario veterinario {get; set;}
        public DetailVeterinarioModel(IRepositorioVeterinario repositorioVeterinario) {
            this.repositorioVeterinario = repositorioVeterinario;
        }

        public void OnGet()
        {
            veterinario = repositorioVeterinario.getVeterinario(cedula);
        }
    }
}
