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
    public class ListMascotasModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        public IEnumerable <Mascota> mascotas;
        public string message {get; set;}
        public string space {get; set;}


       public ListMascotasModel(IRepositorioMascota repositorioMascota) {        
           this.repositorioMascota = repositorioMascota;
           this.message = "En Adopción";
           this.space = " ";
       }

        public void OnGet()
        {
            mascotas = repositorioMascota.getAllMascotas();
        }
    }
}
