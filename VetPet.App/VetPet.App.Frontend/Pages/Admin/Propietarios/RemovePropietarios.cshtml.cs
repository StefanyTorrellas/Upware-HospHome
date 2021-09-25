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
    public class RemovePropietariosModel : PageModel
    {
        
        private readonly IRepositorioPropietario repositorioPropietario;
        public Propietario propietario {get; set;}

        public RemovePropietariosModel(IRepositorioPropietario repositorioPropietario) {
            this.repositorioPropietario = repositorioPropietario;
        }

        public void OnGet(int cedula)
        {
            propietario = repositorioPropietario.getPropietario(cedula);
        }

        public IActionResult OnPost(int cedula) {
            repositorioPropietario.removePropietario(cedula);
            return RedirectToPage("/Admin/Propietarios/ListPropietarios");
        }
    }
}
