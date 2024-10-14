using BodegaVinosAustral.Data;
using BodegaVinosAustral.Entities;

namespace BodegaVinosAustral.Services
{
    public class WineService
    {
        private readonly WineRepository _repository;

        // Inyectamos el repositorio a través del constructor
        public WineService(WineRepository repository)
        {
            _repository = repository;
        }

        // Método para registrar un nuevo vino
        public int RegisterWine(Wine wine)
        {
            return _repository.AddWine(wine);
        }

        // Método para consultar el inventario de vinos
        public IEnumerable<Wine> GetInventory()
        {
            return _repository.GetAllWines();
        }

        // Método para consultar un vino específico por nombre
        public Wine GetWineByName(string name)
        {
            return _repository.GetWineByName(name);
        }
    }
}
