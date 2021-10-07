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
    public class DetailMascotasModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        public Mascota mascota{get; set;}

        public DetailMascotasModel (IRepositorioMascota repositorioMascota) {
            this.repositorioMascota = repositorioMascota;
        }

        public void OnGet(int id)
        {
            mascota = repositorioMascota.getMascota(id);
        }
    }
}
