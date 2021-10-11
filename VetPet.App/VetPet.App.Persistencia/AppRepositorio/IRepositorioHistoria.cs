using System;
using System.Collections.Generic;
using VetPet.App.Dominio;

namespace VetPet.App.Persistencia{
    public interface IRepositorioHistoria{
        IEnumerable<Historia> getAllHistorias();
        Historia getHistoria(int Id);
        Historia editHistoria(Historia historia);
        Historia addHistoria(Historia historia);
        void RemoveHistoria(int Id);

        Historia getHistoriaByMascota(Mascota mascota);
        Historia getHistoriaByVeterinario(Veterinario veterinario);
        //Historia getHistoriaByPacienteAndFecha(Paciente paciente,DateTime fecha_inicio,DateTime fecha_final);
    }
}
