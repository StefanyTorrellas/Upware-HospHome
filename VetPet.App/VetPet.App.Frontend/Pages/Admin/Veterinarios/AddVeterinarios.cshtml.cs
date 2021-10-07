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
    public class AddVeterinariosModel : PageModel
    {

        private readonly IRepositorioVeterinario repositorioVeterinario;
        public Veterinario veterinario {get; set;}
        public AddVeterinariosModel(IRepositorioVeterinario repositorioVeterinario) {
            this.repositorioVeterinario = repositorioVeterinario;
        }

        public void OnGet()
        {
            veterinario = new Veterinario();
        }

        public IActionResult OnPost(Veterinario veterinario) {
	        if (ModelState.IsValid)
            {
            	try {
                    repositorioVeterinario.addVeterinario(veterinario);
                    return Redirect("/admin/veterinarios/list");
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