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
    public class ListHistoriasModel : PageModel
    {
        private readonly IRepositorioHistoria repositorioHistoria;
        public IEnumerable<Historia> historias;
        public Propietario propietario {get; set;}

        public ListHistoriasModel(IRepositorioHistoria repositorioHistoria) {
            this.repositorioHistoria = repositorioHistoria;
        }

        public void OnGet()
        {
            historias = repositorioHistoria.getAllHistorias();
        }
    }
}
