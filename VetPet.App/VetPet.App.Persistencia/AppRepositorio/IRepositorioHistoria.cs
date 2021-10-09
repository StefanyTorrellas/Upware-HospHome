using System.Collections.Generic;
using VetPet.App.Dominio;

namespace VetPet.App.Persistencia
{
    public interface IRepositorioHistoria
    {
        IEnumerable<Historia> getAllHistorias();
        Historia addHistoria(Historia historia);
        Historia editHistoria(Historia historia);
        Historia getHistoria(int id);
        void removeHistoria(int id);
        Historia historiaP(Mascota mascota);
    }
}