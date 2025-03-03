using GestionDhotelesPercistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using GestionDhoteles.Domain.Entities; // Para EstadoHabitacion y OperationResult

namespace GetionDhoteles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoHabitacionController : ControllerBase
    {
        private readonly IEstadoHabitacionRepository _estadoHabitacionRepository;

        public EstadoHabitacionController(IEstadoHabitacionRepository estadoHabitacionRepository)
        {
            _estadoHabitacionRepository = estadoHabitacionRepository;
        }

        // Obtener todos los estados de habitaciones
        [HttpGet("GetAllEstadoHabitaciones")]
        public async Task<IActionResult> GetAllEstadoHabitaciones()
        {
            var estadoHabitaciones = await _estadoHabitacionRepository.GetAllAsync();
            return Ok(estadoHabitaciones);
        }

        // Obtener todos los estados de habitaciones con un filtro
        [HttpGet("GetAllEstadoHabitacionesFiltered")]
        public async Task<IActionResult> GetAllEstadoHabitacionesFiltered([FromQuery] string filter)
        {
            Expression<Func<EstadoHabitacion, bool>> filterExpression = e => e.Descripcion.Contains(filter); // Modifica según tu lógica
            var result = await _estadoHabitacionRepository.GetAllAsync(filterExpression);
            return Ok(result.Data);
        }

        // Obtener un estado de habitación por ID
        [HttpGet("GetEstadoHabitacionById/{id}")]
        public async Task<IActionResult> GetEstadoHabitacionById(int id)
        {
            var estadoHabitacion = await _estadoHabitacionRepository.GetEntityByIdAsync(id);
            if (estadoHabitacion == null)
                return NotFound("Estado de habitación no encontrado");

            return Ok(estadoHabitacion);
        }

        // Guardar un nuevo estado de habitación
        [HttpPost("SaveEstadoHabitacion")]
        public async Task<IActionResult> SaveEstadoHabitacion([FromBody] EstadoHabitacion estadoHabitacion)
        {
            if (estadoHabitacion == null)
                return BadRequest("Datos inválidos");

            var result = await _estadoHabitacionRepository.SaveEntityAsync(estadoHabitacion);
            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetEstadoHabitacionById), new { id = estadoHabitacion.id }, estadoHabitacion);
        }

        // Actualizar un estado de habitación existente
        [HttpPut("UpdateEstadoHabitacion/{id}")]
        public async Task<IActionResult> UpdateEstadoHabitacion(int id, [FromBody] EstadoHabitacion estadoHabitacion)
        {
            if (estadoHabitacion == null || id != estadoHabitacion.id)
                return BadRequest("Datos inválidos");

            var existingEstadoHabitacion = await _estadoHabitacionRepository.GetEntityByIdAsync(id);
            if (existingEstadoHabitacion == null)
                return NotFound("Estado de habitación no encontrado");

            var result = await _estadoHabitacionRepository.UpdateEntityAsync(estadoHabitacion);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // Eliminar un estado de habitación (Deshabilitarlo)
        [HttpDelete("DeleteEstadoHabitacion/{id}")]
        public async Task<IActionResult> DeleteEstadoHabitacion(int id)
        {
            var estadoHabitacion = await _estadoHabitacionRepository.GetEntityByIdAsync(id);
            if (estadoHabitacion == null)
                return NotFound("Estado de habitación no encontrado");

            var result = await _estadoHabitacionRepository.RemoveEntity(id);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // Verificar si un estado de habitación existe por ID
        [HttpGet("ExistsEstadoHabitacion/{id}")]
        public async Task<IActionResult> ExistsEstadoHabitacion(int id)
        {
            var exists = await _estadoHabitacionRepository.Exists(e => e.id == id);
            return Ok(exists);
        }
    }
}
