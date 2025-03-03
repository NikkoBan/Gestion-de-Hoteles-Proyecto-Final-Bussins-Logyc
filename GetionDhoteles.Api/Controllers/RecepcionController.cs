using GestionDhotelesPercistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using GestionDhoteles.Domain.Entities; // Para Recepcion y OperationResult

namespace GetionDhoteles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepcionController : ControllerBase
    {
        private readonly IRecepcionRepository _recepcionRepository;

        public RecepcionController(IRecepcionRepository recepcionRepository)
        {
            _recepcionRepository = recepcionRepository;
        }

        // Obtener todas las recepciones
        [HttpGet("GetAllRecepciones")]
        public async Task<IActionResult> GetAllRecepciones()
        {
            var recepciones = await _recepcionRepository.GetAllAsync();
            return Ok(recepciones);
        }

        // Obtener todas las recepciones con un filtro
        [HttpGet("GetAllRecepcionesFiltered")]
        public async Task<IActionResult> GetAllRecepcionesFiltered([FromQuery] string filter)
        {
            Expression<Func<Recepcion, bool>> filterExpression = r => r.Observacion.Contains(filter); // Modifica según tu lógica
            var result = await _recepcionRepository.GetAllAsync(filterExpression);
            return Ok(result.Data);
        }

        // Obtener una recepcion por ID
        [HttpGet("GetRecepcionById/{id}")]
        public async Task<IActionResult> GetRecepcionById(int id)
        {
            var recepcion = await _recepcionRepository.GetEntityByIdAsync(id);
            if (recepcion == null)
                return NotFound("Recepción no encontrada");

            return Ok(recepcion);
        }

        // Guardar una nueva recepcion
        [HttpPost("SaveRecepcion")]
        public async Task<IActionResult> SaveRecepcion([FromBody] Recepcion recepcion)
        {
            if (recepcion == null)
                return BadRequest("Datos inválidos");

            var result = await _recepcionRepository.SaveEntityAsync(recepcion);
            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetRecepcionById), new { id = recepcion.id }, recepcion);
        }

        // Actualizar una recepcion existente
        [HttpPut("UpdateRecepcion/{id}")]
        public async Task<IActionResult> UpdateRecepcion(int id, [FromBody] Recepcion recepcion)
        {
            if (recepcion == null || id != recepcion.id)
                return BadRequest("Datos inválidos");

            var existingRecepcion = await _recepcionRepository.GetEntityByIdAsync(id);
            if (existingRecepcion == null)
                return NotFound("Recepción no encontrada");

            var result = await _recepcionRepository.UpdateEntityAsync(recepcion);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // Eliminar una recepcion (Deshabilitarla)
        [HttpDelete("DeleteRecepcion/{id}")]
        public async Task<IActionResult> DeleteRecepcion(int id)
        {
            var recepcion = await _recepcionRepository.GetEntityByIdAsync(id);
            if (recepcion == null)
                return NotFound("Recepción no encontrada");

            var result = await _recepcionRepository.RemoveEntity(id);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // Verificar si una recepcion existe por ID
        [HttpGet("ExistsRecepcion/{id}")]
        public async Task<IActionResult> ExistsRecepcion(int id)
        {
            var exists = await _recepcionRepository.Exists(r => r.id == id);
            return Ok(exists);
        }
    }
}
