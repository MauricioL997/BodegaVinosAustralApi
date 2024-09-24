using BodegaVinosAustral.Entities;
using BodegaVinosAustral.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BodegaVinosAustral.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody] User user)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrEmpty(user.Username))
            {
                return BadRequest("El nombre de usuario es obligatorio.");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("La contraseña es obligatoria.");
            }

            _userService.RegisterUser(user);
            return Ok("Usuario registrado con éxito.");
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            if (users == null || !users.Any())
            {
                return NotFound("No hay usuarios registrados.");
            }
            return Ok(users);
        }
    }
}
