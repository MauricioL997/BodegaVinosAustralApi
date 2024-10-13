using BodegaVinosAustral.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BodegaVinosAustral.Data
{
    public class Repository
    {
        // Listas en memoria para vinos y usuarios
        public List<Wine> Wines { get; } = new List<Wine>();
        public List<User> Users { get; } = new List<User>();

        // Métodos para agregar y consultar vinos
        public void AddWine(Wine wine)
        {
            Wines.Add(wine);
        }

        public IEnumerable<Wine> GetAllWines()
        {
            return Wines;
        }

        public Wine GetWineByName(string name)
        {
            return Wines.FirstOrDefault(w => w.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase));
        }

        // Métodos para agregar y consultar usuarios
        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return Users;
        }
    }
}
