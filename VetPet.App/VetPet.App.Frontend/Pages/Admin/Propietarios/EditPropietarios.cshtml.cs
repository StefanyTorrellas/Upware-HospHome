using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using VetPet.App.Dominio;
using VetPet.App.Persistencia;

namespace VetPet.App.Frontend
{
    public class EditPropietariosModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;
        public Propietario propietario {get; set;}
        public EditPropietariosModel(IRepositorioPropietario repositorioPropietario) {
            this.repositorioPropietario = repositorioPropietario;
        }
        public void OnGet(int cedula)
        {
            propietario = repositorioPropietario.getPropietario(cedula);
        }
        public IActionResult OnPost(Propietario propietario) {
            if (ModelState.IsValid)
            {
                try {
                    repositorioPropietario.editPropietario(propietario);
                    return Redirect("/admin/propietarios/list");
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
