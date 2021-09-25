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
    public class AddUsuariosModel : PageModel
    {
        public readonly IRepositorioUsuario repositorioUsuario;
        public Usuario usuario{get; set;}
        public AddUsuariosModel (IRepositorioUsuario repositorioUsuario) {
            this.repositorioUsuario = repositorioUsuario;
        }
        public void OnGet()
        {
            usuario = new Usuario();
        }

        public IActionResult OnPost(Usuario usuario) {
            try {
                repositorioUsuario.addUsuario(usuario);
                return RedirectToPage("/Admin/Usuarios/ListUsuarios");
            }
            catch {
                return RedirectToPage("/Error");
            }
        }
    }
}
