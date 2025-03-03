using GestionDhoteles.Domain.Base;
using GestionDhoteles.Domain.Entities;
using GestionDhotelesPercistence.Base;
using GestionDhotelesPercistence.Context;
using GestionDhotelesPercistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Linq.Expressions;

namespace GestionDhotelesPercistence.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente,int>, IClientesRepository
    {
        private readonly GestionDhotelesDbContext _context;
        private readonly ILogger<ClienteRepository> _logger;
        private readonly IConfiguration _configuration;
        public ClienteRepository(GestionDhotelesDbContext context, ILogger<ClienteRepository> logger, IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }
        public override async Task<bool> Exists(Expression<Func<Cliente, bool>> filter)
        {
            return await _context.Cliente.AnyAsync(filter);
        }
        public override async Task<OperationResult> GetAllAsync(Expression<Func<Cliente, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.Cliente.Where(filter).ToListAsync();
            return result;
        }
        public override async Task<List<Cliente>> GetAllAsync()
        {
            return await _context.Cliente.ToListAsync();
        }
        public override async Task<Cliente> GetEntityByIdAsync(int id)
        {
            return await _context.Cliente.FindAsync(id);
        }
        public override async Task<OperationResult> RemoveEntity(int id)
        {
            OperationResult result = new OperationResult();
            try
            {
                await _context.Piso.Where(e => e.id == id).ExecuteUpdateAsync(setters => setters.SetProperty(e => e.Estado, false));
            }
            catch (Exception ex)
            {

                result.Message = this._configuration["ErrorClienteRepository:RemoveEntity"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public override async Task<OperationResult> SaveEntityAsync(Cliente entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _context.Cliente.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorClienteRepository:SaveEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public override async Task<OperationResult> UpdateEntityAsync(Cliente entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _context.Cliente.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorClienteRepository:UpdateEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
