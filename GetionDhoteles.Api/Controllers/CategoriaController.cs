using GestionDhotelesPercistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using GestionDhoteles.Domain.Entities; // Para OperationResult

namespace GetionDhoteles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriasRepository _categoriaRepository;

        public CategoriaController(ICategoriasRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        // Obtener todas las categorías
        [HttpGet("GetAllCategorias")]
        public async Task<IActionResult> GetAllCategorias()
        {
            var categorias = await _categoriaRepository.GetAllAsync();
            return Ok(categorias);
        }

        // Obtener todas las categorías con un filtro
        [HttpGet("GetAllCategoriasFiltered")]
        public async Task<IActionResult> GetAllCategoriasFiltered([FromQuery] string filter)
        {
            Expression<Func<Categoria, bool>> filterExpression = c => c.Descripcion.Contains(filter); // Modifica según tu lógica
            var result = await _categoriaRepository.GetAllAsync(filterExpression);
            return Ok(result.Data);
        }

        // Obtener una categoría por ID
        [HttpGet("GetCategoriaById/{id}")]
        public async Task<IActionResult> GetCategoriaById(int id)
        {
            var categoria = await _categoriaRepository.GetEntityByIdAsync(id);
            if (categoria == null)
                return NotFound("Categoría no encontrada");

            return Ok(categoria);
        }

        // Guardar una nueva categoría
        [HttpPost("SaveCategoria")]
        public async Task<IActionResult> SaveCategoria([FromBody] Categoria categoria)
        {
            if (categoria == null)
                return BadRequest("Datos inválidos");

            var result = await _categoriaRepository.SaveEntityAsync(categoria);
            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetCategoriaById), new { id = categoria.id }, categoria);
        }

        // Actualizar una categoría existente
        [HttpPut("UpdateCategoria/{id}")]
        public async Task<IActionResult> UpdateCategoria(int id, [FromBody] Categoria categoria)
        {
            if (categoria == null || id != categoria.id)
                return BadRequest("Datos inválidos");

            var existingCategoria = await _categoriaRepository.GetEntityByIdAsync(id);
            if (existingCategoria == null)
                return NotFound("Categoría no encontrada");

            var result = await _categoriaRepository.UpdateEntityAsync(categoria);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // Eliminar una categoría (Deshabilitarla)
        [HttpDelete("DeleteCategoria/{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _categoriaRepository.GetEntityByIdAsync(id);
            if (categoria == null)
                return NotFound("Categoría no encontrada");

            var result = await _categoriaRepository.RemoveEntity(id);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // Verificar si una categoría existe por ID
        [HttpGet("ExistsCategoria/{id}")]
        public async Task<IActionResult> ExistsCategoria(int id)
        {
            var exists = await _categoriaRepository.Exists(c => c.id == id);
            return Ok(exists);
        }
    }
}
