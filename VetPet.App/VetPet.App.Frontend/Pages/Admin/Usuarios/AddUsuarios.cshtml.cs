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
    public class AddUsuariosModel : PageModel
    {
        private readonly IRepositorioUsuario repositorioUsuario;
        public Usuario usuario {get; set;}
        public AddUsuariosModel(IRepositorioUsuario repositorioUsuario) {
            this.repositorioUsuario = repositorioUsuario;
        }

        public void OnGet()
        {
            usuario = new Usuario();
        }

        public IActionResult OnPost(Usuario usuario) {
	        if (ModelState.IsValid)
            {
            	try {
                    repositorioUsuario.addUsuario(usuario);
                    return Redirect("/admin/usuarios/list");
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
