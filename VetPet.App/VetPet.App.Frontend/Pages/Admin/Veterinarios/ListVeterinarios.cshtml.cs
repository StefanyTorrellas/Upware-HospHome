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
    public class ListVeterinariosModel : PageModel
    {

        private readonly IRepositorioVeterinario repositorioVeterinario;
        public IEnumerable<Veterinario> veterinarios {get; set;}
        public ListVeterinariosModel(IRepositorioVeterinario repositorioVeterinario) {        
            this.repositorioVeterinario = repositorioVeterinario;
        }
        public void OnGet()
        {
            veterinarios = repositorioVeterinario.getAllVeterinarios();
        }
    }
}