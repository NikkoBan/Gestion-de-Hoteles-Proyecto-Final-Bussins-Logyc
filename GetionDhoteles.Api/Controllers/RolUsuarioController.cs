using GestionDhotelesPercistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using GestionDhoteles.Domain.Entities; // Para RolUsuario y OperationResult

namespace GetionDhoteles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolUsuarioController : ControllerBase
    {
        private readonly IRolUsuarioRepository _rolUsuarioRepository;

        public RolUsuarioController(IRolUsuarioRepository rolUsuarioRepository)
        {
            _rolUsuarioRepository = rolUsuarioRepository;
        }

        // Obtener todos los roles de usuario
        [HttpGet("GetAllRolesUsuario")]
        public async Task<IActionResult> GetAllRolesUsuario()
        {
            var rolesUsuario = await _rolUsuarioRepository.GetAllAsync();
            return Ok(rolesUsuario);
        }

        // Obtener todos los roles de usuario con un filtro
        [HttpGet("GetAllRolesUsuarioFiltered")]
        public async Task<IActionResult> GetAllRolesUsuarioFiltered([FromQuery] string filter)
        {
            Expression<Func<RolUsuario, bool>> filterExpression = r => r.Descripcion.Contains(filter); // Modifica según tu lógica
            var result = await _rolUsuarioRepository.GetAllAsync(filterExpression);
            return Ok(result.Data);
        }

        // Obtener un rol de usuario por ID
        [HttpGet("GetRolUsuarioById/{id}")]
        public async Task<IActionResult> GetRolUsuarioById(int id)
        {
            var rolUsuario = await _rolUsuarioRepository.GetEntityByIdAsync(id);
            if (rolUsuario == null)
                return NotFound("Rol de usuario no encontrado");

            return Ok(rolUsuario);
        }

        // Guardar un nuevo rol de usuario
        [HttpPost("SaveRolUsuario")]
        public async Task<IActionResult> SaveRolUsuario([FromBody] RolUsuario rolUsuario)
        {
            if (rolUsuario == null)
                return BadRequest("Datos inválidos");

            var result = await _rolUsuarioRepository.SaveEntityAsync(rolUsuario);
            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetRolUsuarioById), new { id = rolUsuario.id }, rolUsuario);
        }

        // Actualizar un rol de usuario existente
        [HttpPut("UpdateRolUsuario/{id}")]
        public async Task<IActionResult> UpdateRolUsuario(int id, [FromBody] RolUsuario rolUsuario)
        {
            if (rolUsuario == null || id != rolUsuario.id)
                return BadRequest("Datos inválidos");

            var existingRolUsuario = await _rolUsuarioRepository.GetEntityByIdAsync(id);
            if (existingRolUsuario == null)
                return NotFound("Rol de usuario no encontrado");

            var result = await _rolUsuarioRepository.UpdateEntityAsync(rolUsuario);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // Eliminar un rol de usuario (Deshabilitarlo)
        [HttpDelete("DeleteRolUsuario/{id}")]
        public async Task<IActionResult> DeleteRolUsuario(int id)
        {
            var rolUsuario = await _rolUsuarioRepository.GetEntityByIdAsync(id);
            if (rolUsuario == null)
                return NotFound("Rol de usuario no encontrado");

            var result = await _rolUsuarioRepository.RemoveEntity(id);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // Verificar si un rol de usuario existe por ID
        [HttpGet("ExistsRolUsuario/{id}")]
        public async Task<IActionResult> ExistsRolUsuario(int id)
        {
            var exists = await _rolUsuarioRepository.Exists(r => r.id == id);
            return Ok(exists);
        }
    }
}
