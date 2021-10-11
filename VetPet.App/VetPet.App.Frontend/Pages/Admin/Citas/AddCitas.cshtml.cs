using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VetPet.App.Dominio;
using VetPet.App.Persistencia;

namespace VetPet.App.Frontend
{
    public class AddCitasModel : PageModel
    {

        private readonly IRepositorioCita repositorioCita;
        private readonly IRepositorioVeterinario repositorioVeterinario;
        private readonly IRepositorioMascota repositorioMascota;

        public SelectList veterinarios {get; set;}
        public SelectList mascotas {get; set;}

        public int cedulaVeterinario {get; set;}
        public int idMascota {get; set;}
        public Cita cita {get; set;}
        public String mensaje {get; set;}

        public AddCitasModel(IRepositorioCita repositorioCita, IRepositorioVeterinario repositorioVeterinario, IRepositorioMascota repositorioMascota) {
            this.repositorioCita = repositorioCita;
            this.repositorioVeterinario = repositorioVeterinario;
            this.repositorioMascota = repositorioMascota;               
        }

        public void OnGet()
        {
            cita = new Cita();
            veterinarios = new SelectList(repositorioVeterinario.getAllVeterinarios(),nameof(Veterinario.cedula),nameof(Veterinario.nombre));
            mascotas = new SelectList(repositorioMascota.getAllMascotas(),nameof(Mascota.id),nameof(Mascota.nombre));
        }

        public IActionResult OnPost(Cita cita, int cedulaVeterinario, int idMascota) {
            Veterinario veterinario = repositorioVeterinario.getVeterinario(cedulaVeterinario);
            Mascota mascota = repositorioMascota.getMascota(idMascota);
            /*
            Cita nuevaCita = new Cita() {
                veterinario = veterinario,
                mascota = mascota,
                hora = cita.hora,
                dia = cita.dia,
                descripcion = cita.descripcion
            };
            */
            if (ModelState.IsValid) {
                
                Cita citaInsertada = repositorioCita.addCita(cita);
                cita.veterinario = veterinario;
                cita.mascota = mascota;
                if (citaInsertada != null) {
                    return RedirectToPage("/Admin/Citas/ListCitas");
                }
                else {
                    mensaje = "El medico tiene una cita a esa hora";
                    return Page();
                }
            }
            else {
                return Page();
            }

        }
    }
}
