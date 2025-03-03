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
    public class RolUsuarioRepository : BaseRepository<RolUsuario, int>, IRolUsuarioRepository
    {
        private readonly GestionDhotelesDbContext _context;
        private readonly ILogger<RolUsuarioRepository> _logger;
        private readonly IConfiguration _configuration;
        public RolUsuarioRepository(GestionDhotelesDbContext context, ILogger<RolUsuarioRepository> logger, IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }
        public override async Task<bool> Exists(Expression<Func<RolUsuario, bool>> filter)
        {
            return await _context.RolUsuario.AnyAsync(filter);
        }
        public override async Task<OperationResult> GetAllAsync(Expression<Func<RolUsuario, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.RolUsuario.Where(filter).ToListAsync();
            return result;
        }
        public override async Task<List<RolUsuario>> GetAllAsync()
        {
            return await _context.RolUsuario.ToListAsync();
        }
        public override async Task<RolUsuario> GetEntityByIdAsync(int id)
        {
            return await _context.RolUsuario.FindAsync(id);
        }
        public override async Task<OperationResult> RemoveEntity(int id)
        {
            OperationResult result = new OperationResult();
            try
            {
                await _context.RolUsuario.Where(e => e.id == id).ExecuteUpdateAsync(setters => setters.SetProperty(e => e.Estado, false));
            }
            catch (Exception ex)
            {

                result.Message = this._configuration["ErrorRolUsuarioRepository:RemoveEntity"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public override async Task<OperationResult> SaveEntityAsync(RolUsuario entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _context.RolUsuario.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorRolUsuarioRepository:SaveEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public override async Task<OperationResult> UpdateEntityAsync(RolUsuario entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _context.RolUsuario.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorRolUsuarioRepository:UpdateEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
