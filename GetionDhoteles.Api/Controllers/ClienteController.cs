using GestionDhotelesPercistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using GestionDhoteles.Domain.Entities; // Para OperationResult

namespace GetionDhoteles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClientesRepository _clienteRepository;

        public ClienteController(IClientesRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // Obtener todos los clientes
        [HttpGet("GetAllClientes")]
        public async Task<IActionResult> GetAllClientes()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return Ok(clientes);
        }

        // Obtener todos los clientes con un filtro
        [HttpGet("GetAllClientesFiltered")]
        public async Task<IActionResult> GetAllClientesFiltered([FromQuery] string filter)
        {
            Expression<Func<Cliente, bool>> filterExpression = c => c.NombreCompleto.Contains(filter); // Modifica según tu lógica
            var result = await _clienteRepository.GetAllAsync(filterExpression);
            return Ok(result.Data);
        }

        // Obtener un cliente por ID
        [HttpGet("GetClienteById/{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = await _clienteRepository.GetEntityByIdAsync(id);
            if (cliente == null)
                return NotFound("Cliente no encontrado");

            return Ok(cliente);
        }

        // Guardar un nuevo cliente
        [HttpPost("SaveCliente")]
        public async Task<IActionResult> SaveCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest("Datos inválidos");

            var result = await _clienteRepository.SaveEntityAsync(cliente);
            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetClienteById), new { id = cliente.id }, cliente);
        }

        // Actualizar un cliente existente
        [HttpPut("UpdateCliente/{id}")]
        public async Task<IActionResult> UpdateCliente(int id, [FromBody] Cliente cliente)
        {
            if (cliente == null || id != cliente.id)
                return BadRequest("Datos inválidos");

            var existingCliente = await _clienteRepository.GetEntityByIdAsync(id);
            if (existingCliente == null)
                return NotFound("Cliente no encontrado");

            var result = await _clienteRepository.UpdateEntityAsync(cliente);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // Eliminar un cliente (Deshabilitarlo)
        [HttpDelete("DeleteCliente/{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _clienteRepository.GetEntityByIdAsync(id);
            if (cliente == null)
                return NotFound("Cliente no encontrado");

            var result = await _clienteRepository.RemoveEntity(id);
            if (!result.Success)
                return BadRequest(result.Message);

            return NoContent();
        }

        // Verificar si un cliente existe por ID
        [HttpGet("ExistsCliente/{id}")]
        public async Task<IActionResult> ExistsCliente(int id)
        {
            var exists = await _clienteRepository.Exists(c => c.id == id);
            return Ok(exists);
        }
    }
}
