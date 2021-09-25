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
    public class ListUsuariosModel : PageModel
    {
        private readonly IRepositorioUsuario repositorioUsuario;
        public IEnumerable<Usuario> usuarios;
        public ListUsuariosModel(IRepositorioUsuario repositorioUsuario) {
            this.repositorioUsuario = repositorioUsuario;
        }

        public void OnGet()
        {
            usuarios = repositorioUsuario.getAllUsuarios();
        }
    }
}
