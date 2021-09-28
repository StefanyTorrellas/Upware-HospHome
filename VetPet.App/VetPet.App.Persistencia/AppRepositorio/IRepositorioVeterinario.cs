using System.Collections.Generic;
using VetPet.App.Dominio;

namespace VetPet.App.Persistencia
{
    public interface IRepositorioVeterinario
    {
        IEnumerable<Veterinario> getAllVeterinarios();
        Veterinario addVeterinario(Veterinario veterinario);
        Veterinario editVeterinario(Veterinario veterinario);
        Veterinario getVeterinario(int cedula);
        void removeVeterinario(int cedula);
    }
}
