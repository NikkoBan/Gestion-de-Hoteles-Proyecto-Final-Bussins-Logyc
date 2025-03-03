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
    public class UsuarioRepository : BaseRepository<Usuario, int>, IUsuarioRepository
    {
        private readonly GestionDhotelesDbContext _context;
        private readonly ILogger<UsuarioRepository> _logger;
        private readonly IConfiguration _configuration;
        public UsuarioRepository(GestionDhotelesDbContext context, ILogger<UsuarioRepository> logger, IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }
        public override async Task<bool> Exists(Expression<Func<Usuario, bool>> filter)
        {
            return await _context.Usuario.AnyAsync(filter);
        }
        public override async Task<OperationResult> GetAllAsync(Expression<Func<Usuario, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.Usuario.Where(filter).ToListAsync();
            return result;
        }
        public override async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuario.ToListAsync();
        }
        public override async Task<Usuario> GetEntityByIdAsync(int id)
        {
            return await _context.Usuario.FindAsync(id);
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

                result.Message = this._configuration["ErrorUsuarioRepository:RemoveEntity"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public override async Task<OperationResult> SaveEntityAsync(Usuario entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _context.Usuario.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorUsuarioRepository:SaveEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public override async Task<OperationResult> UpdateEntityAsync(Usuario entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _context.Usuario.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorUsuarioRepository:UpdateEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
