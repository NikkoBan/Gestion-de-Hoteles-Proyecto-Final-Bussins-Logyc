using GestionDhotelesPercistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using GestionDhoteles.Domain.Entities; // Para Habitacion y OperationResult

namespace GetionDhoteles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        private readonly IHabitacionRepository _habitacionRepository;

        public HabitacionController(IHabitacionRepository habitacionRepository)
        {
            _habitacionRepository = habitacionRepository;
        }

        // Obtener todas las habitaciones
        [HttpGet("GetAllHabitaciones")]
        public async Task<IActionResult> GetAllHabitaciones()
        {
            var habitaciones = await _habitacionRepository.GetAllAsync();
            return Ok(habitaciones);
        }

        // Obtener todas las habitaciones con un filtro
        [HttpGet("GetAllHabitacionesFiltered")]
        public async Task<IActionResult> GetAllHabitacionesFiltered([FromQuery] string filter)
        {
            Expression<Func<Habitacion, bool>> filterExpression = h => h.Numero.Contains(filter) || h.Detalle.Contains(filter); // Modifica según tu lógica
            var result = await _habitacionRepository.GetAllAsync(filterExpression);
            return Ok(result.Data);
        }

        // Obtener una habitación por ID
        [HttpGet("GetHabitacionById/{id}")]
        public async Task<IActionResult> GetHabitacionById(int id)
        {
            var habitacion = await _habitacionRepository.GetEntityByIdAsync(id);
            if (habitacion == null)
                return NotFound("Habitación no encontrada");

            return Ok(habitacion);
        }

        // Guardar una nueva habitación
        [HttpPost("SaveHabitacion")]
        public async Task<IActionResult> SaveHabitacion([FromBody] Habitacion habitacion)
        {
            if (habitacion == null)
                return BadRequest("Datos inválidos");

            var result = await _habitacionRepository.SaveEntityAsync(habitacion);
            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetHabitacionById), new { id = habitacion.id }, habitacion);
        }

        // Actualizar una habitación existente
        [HttpPut("UpdateHabitacion/{id}")]
        public async Task<IActionResult> UpdateHabitacion(int id, [FromBody] Habitacion habitacion)
        {
            if (habitacion == null || id != habitacion.id)
                return BadRequest("Datos inválidos");

            var existingHabitacion = await _habitacionRepository.GetEntityByIdAsync(id);
            if (existingHabitacion == null)
                return NotFound("Habitación no encontrada");

            var result = await _habitacionRepository.UpdateEntityAsync(habitacion);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // Eliminar una habitación (Deshabilitarla)
        [HttpDelete("DeleteHabitacion/{id}")]
        public async Task<IActionResult> DeleteHabitacion(int id)
        {
            var habitacion = await _habitacionRepository.GetEntityByIdAsync(id);
            if (habitacion == null)
                return NotFound("Habitación no encontrada");

            var result = await _habitacionRepository.RemoveEntity(id);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // Verificar si una habitación existe por ID
        [HttpGet("ExistsHabitacion/{id}")]
        public async Task<IActionResult> ExistsHabitacion(int id)
        {
            var exists = await _habitacionRepository.Exists(h => h.id == id);
            return Ok(exists);
        }
    }
}
