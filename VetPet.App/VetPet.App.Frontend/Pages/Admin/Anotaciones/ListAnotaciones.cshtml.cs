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
    public class ListAnotacionesModel : PageModel
    {
        private readonly IRepositorioAnotacion repositorioAnotacion;
        public IEnumerable<Anotacion> anotaciones;

        public ListAnotacionesModel(IRepositorioAnotacion repositorioAnotacion) {
            this.repositorioAnotacion = repositorioAnotacion;
        }
        public void OnGet()
        {
            anotaciones = repositorioAnotacion.getAllAnotaciones();
        }
    }
}
