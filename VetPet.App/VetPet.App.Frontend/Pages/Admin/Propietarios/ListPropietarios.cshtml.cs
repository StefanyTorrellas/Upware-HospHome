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
    public class ListPropietariosModel : PageModel
    {

        private readonly IRepositorioPropietario repositorioPropietario;
        public IEnumerable<Propietario>propietarios;
        public ListPropietariosModel(IRepositorioPropietario repositorioPropietario) {        
            this.repositorioPropietario = repositorioPropietario;
        }
        public void OnGet()
        {
            propietarios = repositorioPropietario.getAllPropietarios();
        }
    }
}
