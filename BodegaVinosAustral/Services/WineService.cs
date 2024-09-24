using BodegaVinosAustral.Data;
using BodegaVinosAustral.Entities;
using System.Collections.Generic;

namespace BodegaVinosAustral.Services
{
    public class WineService
    {
        private readonly InMemoryRepository _repository;

        // Inyectamos el repositorio a través del constructor
        public WineService(InMemoryRepository repository)
        {
            _repository = repository;
        }

        // Método para registrar un nuevo vino
        public void RegisterWine(Wine wine)
        {
            _repository.AddWine(wine);
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
