using BodegaVinosAustral.Common.DTOs;
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
        public IActionResult RegisterWine([FromBody] WineDTO wineDTO)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrEmpty(wineDTO.Name))
            {
                return BadRequest("El nombre del vino es obligatorio.");
            }

            if (string.IsNullOrEmpty(wineDTO.Variety))
            {
                return BadRequest("La variedad del vino es obligatoria.");
            }

            if (wineDTO.Year <= 0)
            {
                return BadRequest("Debe ingresar un año válido para el vino.");
            }

            if (wineDTO.Stock < 0)
            {
                return BadRequest("El stock no puede ser negativo.");
            }

            var newWine = new Wine
            {
                Name = wineDTO.Name,
                Variety = wineDTO.Variety,
                Year = wineDTO.Year,
                Region = wineDTO.Region,
                Stock = wineDTO.Stock,
                CreatedAt = DateTime.UtcNow
            };

            _wineService.RegisterWine(newWine);
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

            // Mapeo de Wine a WineDTO
            var wineDtos = wines.Select(w => new WineDTO
            {
                Name = w.Name,
                Variety = w.Variety,
                Year = w.Year,
                Region = w.Region,
                Stock = w.Stock
            }).ToList();

            return Ok(wineDtos);
        }


        [HttpGet("{name}")]
        public IActionResult GetWineByName(string name)
        {
            var wine = _wineService.GetWineByName(name);
            if (wine == null)
            {
                return NotFound("Vino no encontrado.");
            }

            // Mapeo de Wine a WineDTO
            var wineDto = new WineDTO
            {
                Name = wine.Name,
                Variety = wine.Variety,
                Year = wine.Year,
                Region = wine.Region,
                Stock = wine.Stock
            };

            return Ok(wineDto);
        }
    }
}