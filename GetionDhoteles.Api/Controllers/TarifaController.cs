using GestionDhotelesPercistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using GestionDhoteles.Domain.Entities; // Para Tarifa y OperationResult

namespace GetionDhoteles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarifaController : ControllerBase
    {
        private readonly ITarifaRepository _tarifaRepository;

        public TarifaController(ITarifaRepository tarifaRepository)
        {
            _tarifaRepository = tarifaRepository;
        }


        [HttpGet("GetAllTarifas")]
        public async Task<IActionResult> GetAllTarifas()
        {
            var tarifas = await _tarifaRepository.GetAllAsync();
            return Ok(tarifas);
        }


        [HttpGet("GetAllTarifasFiltered")]
        public async Task<IActionResult> GetAllTarifasFiltered([FromQuery] string filter)
        {
            Expression<Func<Tarifa, bool>> filterExpression = t => t.Descripcion.Contains(filter); // Modifica según tu lógica
            var result = await _tarifaRepository.GetAllAsync(filterExpression);
            return Ok(result.Data);
        }

        [HttpGet("GetTarifaById/{id}")]
        public async Task<IActionResult> GetTarifaById(int id)
        {
            var tarifa = await _tarifaRepository.GetEntityByIdAsync(id);
            if (tarifa == null)
                return NotFound("Tarifa no encontrada");

            return Ok(tarifa);
        }


        [HttpPost("SaveTarifa")]
        public async Task<IActionResult> SaveTarifa([FromBody] Tarifa tarifa)
        {
            if (tarifa == null)
                return BadRequest("Datos inválidos");

            var result = await _tarifaRepository.SaveEntityAsync(tarifa);
            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetTarifaById), new { id = tarifa.id }, tarifa);
        }

     
        [HttpPut("UpdateTarifa/{id}")]
        public async Task<IActionResult> UpdateTarifa(int id, [FromBody] Tarifa tarifa)
        {
            if (tarifa == null || id != tarifa.id)
                return BadRequest("Datos inválidos");

            var existingTarifa = await _tarifaRepository.GetEntityByIdAsync(id);
            if (existingTarifa == null)
                return NotFound("Tarifa no encontrada");

            var result = await _tarifaRepository.UpdateEntityAsync(tarifa);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpDelete("DeleteTarifa/{id}")]
        public async Task<IActionResult> DeleteTarifa(int id)
        {
            var tarifa = await _tarifaRepository.GetEntityByIdAsync(id);
            if (tarifa == null)
                return NotFound("Tarifa no encontrada");

            var result = await _tarifaRepository.RemoveEntity(id);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpGet("ExistsTarifa/{id}")]
        public async Task<IActionResult> ExistsTarifa(int id)
        {
            var exists = await _tarifaRepository.Exists(t => t.id == id);
            return Ok(exists);
        }
    }
}
