using BodegaVinosAustral.Entities;
using BodegaVinosAustral.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BodegaVinosAustral.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WineController : ControllerBase
    {
        private readonly WineService _wineService;

        public WineController(WineService wineService)
        {
            _wineService = wineService;
        }

        [HttpPost]
        public IActionResult RegisterWine([FromBody] Wine wine)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrEmpty(wine.Name))
            {
                return BadRequest("El nombre del vino es obligatorio.");
            }

            if (string.IsNullOrEmpty(wine.Variety))
            {
                return BadRequest("La variedad del vino es obligatoria.");
            }

            if (wine.Year <= 0)
            {
                return BadRequest("Debe ingresar un año válido para el vino.");
            }

            if (wine.Stock < 0)
            {
                return BadRequest("El stock no puede ser negativo.");
            }

            _wineService.RegisterWine(wine);
            return Ok("Vino registrado con éxito.");
        }

        [HttpGet]
        public IActionResult GetInventory()
        {
            var wines = _wineService.GetInventory();
            if (wines == null || !wines.Any())
            {
                return NotFound("No hay vinos en el inventario.");
            }
            return Ok(wines);
        }

        [HttpGet("{name}")]
        public IActionResult GetWineByName(string name)
        {
            var wine = _wineService.GetWineByName(name);
            if (wine == null)
            {
                return NotFound("Vino no encontrado.");
            }
            return Ok(wine);
        }
    }
}
