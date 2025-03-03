using GestionDhotelesPercistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using GestionDhoteles.Domain.Entities; // Para Usuario y OperationResult

namespace GetionDhoteles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // Obtener todos los usuarios
        [HttpGet("GetAllUsuarios")]
        public async Task<IActionResult> GetAllUsuarios()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return Ok(usuarios);
        }

        // Obtener todos los usuarios con un filtro
        [HttpGet("GetAllUsuariosFiltered")]
        public async Task<IActionResult> GetAllUsuariosFiltered([FromQuery] string filter)
        {
            Expression<Func<Usuario, bool>> filterExpression = u => u.NombreCompleto.Contains(filter) || u.Correo.Contains(filter); // Modifica según tu lógica
            var result = await _usuarioRepository.GetAllAsync(filterExpression);
            return Ok(result.Data);
        }

        // Obtener un usuario por ID
        [HttpGet("GetUsuarioById/{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            var usuario = await _usuarioRepository.GetEntityByIdAsync(id);
            if (usuario == null)
                return NotFound("Usuario no encontrado");

            return Ok(usuario);
        }

        // Guardar un nuevo usuario
        [HttpPost("SaveUsuario")]
        public async Task<IActionResult> SaveUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest("Datos inválidos");

            var result = await _usuarioRepository.SaveEntityAsync(usuario);
            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.id }, usuario);
        }

        // Actualizar un usuario existente
        [HttpPut("UpdateUsuario/{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] Usuario usuario)
        {
            if (usuario == null || id != usuario.id)
                return BadRequest("Datos inválidos");

            var existingUsuario = await _usuarioRepository.GetEntityByIdAsync(id);
            if (existingUsuario == null)
                return NotFound("Usuario no encontrado");

            var result = await _usuarioRepository.UpdateEntityAsync(usuario);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // Eliminar un usuario (Deshabilitarlo)
        [HttpDelete("DeleteUsuario/{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _usuarioRepository.GetEntityByIdAsync(id);
            if (usuario == null)
                return NotFound("Usuario no encontrado");

            var result = await _usuarioRepository.RemoveEntity(id);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // Verificar si un usuario existe por ID
        [HttpGet("ExistsUsuario/{id}")]
        public async Task<IActionResult> ExistsUsuario(int id)
        {
            var exists = await _usuarioRepository.Exists(u => u.id == id);
            return Ok(exists);
        }
    }
}
