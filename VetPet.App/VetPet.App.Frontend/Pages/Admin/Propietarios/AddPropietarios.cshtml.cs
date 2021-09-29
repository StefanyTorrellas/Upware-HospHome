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
    public class AddPropietariosModel : PageModel
    {

        private readonly IRepositorioPropietario repositorioPropietario;
        public Propietario propietario {get; set;}
        public AddPropietariosModel(IRepositorioPropietario repositorioPropietario) {
            this.repositorioPropietario = repositorioPropietario;
        }

        public void OnGet()
        {
            propietario = new Propietario();
        }

        public IActionResult OnPost(Propietario propietario) {
	        if (ModelState.IsValid)
            {
            	try {
                    repositorioPropietario.addPropietario(propietario);
                    return Redirect("/admin/propietarios/list");
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
