using BodegaVinosAustral.Data;
using BodegaVinosAustral.Entities;

namespace BodegaVinosAustral.Services
{
    public class UserService
    {
        private readonly Repository _repository;

        // Inyectamos el repositorio a través del constructor
        public UserService(Repository repository)
        {
            _repository = repository;
        }

        // Método para registrar un nuevo usuario
        public void RegisterUser(User user)
        {
            _repository.AddUser(user);
        }

        // Método para obtener todos los usuarios
        public IEnumerable<User> GetAllUsers()
        {
            return _repository.GetAllUsers();
        }
    }
}
