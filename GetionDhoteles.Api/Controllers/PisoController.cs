using GestionDhotelesPercistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using GestionDhoteles.Domain.Entities; // Para Piso y OperationResult

namespace GetionDhoteles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PisoController : ControllerBase
    {
        private readonly IPisoRepository _pisoRepository;

        public PisoController(IPisoRepository pisoRepository)
        {
            _pisoRepository = pisoRepository;
        }

        // Obtener todos los pisos
        [HttpGet("GetAllPisos")]
        public async Task<IActionResult> GetAllPisos()
        {
            var pisos = await _pisoRepository.GetAllAsync();
            return Ok(pisos);
        }

        // Obtener todos los pisos con un filtro
        [HttpGet("GetAllPisosFiltered")]
        public async Task<IActionResult> GetAllPisosFiltered([FromQuery] string filter)
        {
            Expression<Func<Piso, bool>> filterExpression = p => p.Descripcion.Contains(filter); // Modifica según tu lógica
            var result = await _pisoRepository.GetAllAsync(filterExpression);
            return Ok(result.Data);
        }

        // Obtener un piso por ID
        [HttpGet("GetPisoById/{id}")]
        public async Task<IActionResult> GetPisoById(int id)
        {
            var piso = await _pisoRepository.GetEntityByIdAsync(id);
            if (piso == null)
                return NotFound("Piso no encontrado");

            return Ok(piso);
        }

        // Guardar un nuevo piso
        [HttpPost("SavePiso")]
        public async Task<IActionResult> SavePiso([FromBody] Piso piso)
        {
            if (piso == null)
                return BadRequest("Datos inválidos");

            var result = await _pisoRepository.SaveEntityAsync(piso);
            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetPisoById), new { id = piso.id }, piso);
        }

        // Actualizar un piso existente
        [HttpPut("UpdatePiso/{id}")]
        public async Task<IActionResult> UpdatePiso(int id, [FromBody] Piso piso)
        {
            if (piso == null || id != piso.id)
                return BadRequest("Datos inválidos");

            var existingPiso = await _pisoRepository.GetEntityByIdAsync(id);
            if (existingPiso == null)
                return NotFound("Piso no encontrado");

            var result = await _pisoRepository.UpdateEntityAsync(piso);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // Eliminar un piso (Deshabilitarlo)
        [HttpDelete("DeletePiso/{id}")]
        public async Task<IActionResult> DeletePiso(int id)
        {
            var piso = await _pisoRepository.GetEntityByIdAsync(id);
            if (piso == null)
                return NotFound("Piso no encontrado");

            var result = await _pisoRepository.RemoveEntity(id);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // Verificar si un piso existe por ID
        [HttpGet("ExistsPiso/{id}")]
        public async Task<IActionResult> ExistsPiso(int id)
        {
            var exists = await _pisoRepository.Exists(p => p.id == id);
            return Ok(exists);
        }
    }
}
