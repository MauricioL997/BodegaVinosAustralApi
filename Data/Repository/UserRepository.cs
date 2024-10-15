using BodegaVinosAustral.Entities;
using Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BodegaVinosAustral.Data
{
    public class UserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public User? Authenticate(string username, string password)
        {
            User userAthenticate = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return userAthenticate;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
        public int AddUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return user.Id;  // Retornamos el Id del usuario recién agregado
            }
            catch (DbUpdateException ex)
            {
                // Muestra el mensaje de error detallado
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
        }
    }
}
