using GestionDhotelesPercistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using GestionDhoteles.Domain.Entities; // Para Servicio y OperationResult

namespace GetionDhoteles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioRepository _servicioRepository;

        public ServicioController(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        // Obtener todos los servicios
        [HttpGet("GetAllServicios")]
        public async Task<IActionResult> GetAllServicios()
        {
            var servicios = await _servicioRepository.GetAllAsync();
            return Ok(servicios);
        }

        // Obtener todos los servicios con un filtro
        [HttpGet("GetAllServiciosFiltered")]
        public async Task<IActionResult> GetAllServiciosFiltered([FromQuery] string filter)
        {
            Expression<Func<Servicio, bool>> filterExpression = s => s.Nombre.Contains(filter) || s.Descripcion.Contains(filter); // Modifica según tu lógica
            var result = await _servicioRepository.GetAllAsync(filterExpression);
            return Ok(result.Data);
        }

        // Obtener un servicio por ID
        [HttpGet("GetServicioById/{id}")]
        public async Task<IActionResult> GetServicioById(short id)
        {
            var servicio = await _servicioRepository.GetEntityByIdAsync(id);
            if (servicio == null)
                return NotFound("Servicio no encontrado");

            return Ok(servicio);
        }

        // Guardar un nuevo servicio
        [HttpPost("SaveServicio")]
        public async Task<IActionResult> SaveServicio([FromBody] Servicio servicio)
        {
            if (servicio == null)
                return BadRequest("Datos inválidos");

            var result = await _servicioRepository.SaveEntityAsync(servicio);
            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetServicioById), new { id = servicio.id }, servicio);
        }

        // Actualizar un servicio existente
        [HttpPut("UpdateServicio/{id}")]
        public async Task<IActionResult> UpdateServicio(short id, [FromBody] Servicio servicio)
        {
            if (servicio == null || id != servicio.id)
                return BadRequest("Datos inválidos");

            var existingServicio = await _servicioRepository.GetEntityByIdAsync(id);
            if (existingServicio == null)
                return NotFound("Servicio no encontrado");

            var result = await _servicioRepository.UpdateEntityAsync(servicio);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // Eliminar un servicio (Deshabilitarlo)
        [HttpDelete("DeleteServicio/{id}")]
        public async Task<IActionResult> DeleteServicio(short id)
        {
            var servicio = await _servicioRepository.GetEntityByIdAsync(id);
            if (servicio == null)
                return NotFound("Servicio no encontrado");

            var result = await _servicioRepository.RemoveEntity(id);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // Verificar si un servicio existe por ID
        [HttpGet("ExistsServicio/{id}")]
        public async Task<IActionResult> ExistsServicio(short id)
        {
            var exists = await _servicioRepository.Exists(s => s.id == id);
            return Ok(exists);
        }
    }
}
