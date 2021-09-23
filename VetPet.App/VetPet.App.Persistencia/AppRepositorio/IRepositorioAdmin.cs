using System.Collections.Generic;
using VetPet.App.Dominio;

namespace VetPet.App.Persistencia
{
    public interface IRepositorioAdmin
    {
        IEnumerable<Admin> getAllAdmins();
        Admin addAdmin(Admin admin);
        Admin editAdmin(Admin admin);
        Admin getAdmin(int id);
        void removeAdmin(int id);
    }
}
