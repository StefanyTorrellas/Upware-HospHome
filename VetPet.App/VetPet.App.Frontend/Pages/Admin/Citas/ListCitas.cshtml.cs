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

        [DataType(DataType.Date),Range(typeof(DateTime), "1/1/2021", "31/12/2025", ErrorMessage = "El valor {0} debe estar {1} y {2}")]
        public DateTime Dia {get; set;}

        [DataType(DataType.Date),Range(typeof(DateTime), "1/1/2021", "31/12/2025", ErrorMessage = "El valor {0} debe estar {1} y {2}")]
        public DateTime DiaInicial {get; set;}

        [DataType(DataType.Date),Range(typeof(DateTime), "1/1/2021", "31/12/2025", ErrorMessage = "El valor {0} debe estar {1} y {2}")]
        public DateTime DiaFinal {get; set;}

        public ListCitasModel(IRepositorioCita repositorioCita) {
            this.repositorioCita = repositorioCita;
        }

        public void OnGet()
        {
            citas = repositorioCita.getAllCitas();
        }
    }
}
