using BodegaVinosAustral.Entities; // Entidades
using BodegaVinosAustral.Services; // Servicios
using common.DTOs.BodegaVinosAustral.Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
        public IActionResult RegisterUser([FromBody] UserDTO userDto)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrEmpty(userDto.Username))
            {
                return BadRequest("El nombre de usuario es obligatorio.");
            }

            if (string.IsNullOrEmpty(userDto.Password))
            {
                return BadRequest("La contraseña es obligatoria.");
            }

            // Mapeo de DTO a entidad
            var newUser = new User
            {
                Username = userDto.Username,
                Password = userDto.Password
            };

            _userService.RegisterUser(newUser);
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

            // Mapeo de entidad a DTO
            var userDtos = users.Select(user => new UserDTO
            {
                Username = user.Username
                // Añade más campos si es necesario
            }).ToList();

            return Ok(userDtos);
        }
    }
}
