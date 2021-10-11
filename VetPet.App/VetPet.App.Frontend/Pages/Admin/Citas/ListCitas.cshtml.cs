using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VetPet.App.Dominio;
using VetPet.App.Persistencia;


namespace VetPet.App.Frontend
{
    public class ListCitasModel : PageModel
    {

        private readonly IRepositorioCita repositorioCita;
        public IEnumerable<Cita> citas;

        public ListCitasModel(IRepositorioCita repositorioCita) {
            this.repositorioCita = repositorioCita;
        }

        public void OnGet()
        {
            citas = repositorioCita.getAllCitas();
        }
    }
}
