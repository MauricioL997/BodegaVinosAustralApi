using BodegaVinosAustral.Data;
using BodegaVinosAustral.Entities;

namespace BodegaVinosAustral.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;

        // Inyectamos el repositorio a través del constructor
        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        // Método para registrar un nuevo usuario
        public int RegisterUser(User user)
        {
            // Agregar el usuario y retornar el Id
            return _repository.AddUser(user);
        }

        // Método para obtener todos los usuarios
        public IEnumerable<User> GetAllUsers()
        {
            return _repository.GetAllUsers();
        }
    }
}

