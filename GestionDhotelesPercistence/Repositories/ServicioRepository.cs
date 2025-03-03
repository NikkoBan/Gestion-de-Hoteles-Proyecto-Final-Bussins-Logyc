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
    public class ServicioRepository : BaseRepository<Servicio, short>, IServicioRepository
    {
        private readonly GestionDhotelesDbContext _context;
        private readonly ILogger<ServicioRepository> _logger;
        private readonly IConfiguration _configuration;
        public ServicioRepository(GestionDhotelesDbContext context, ILogger<ServicioRepository> logger, IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }
        public override async Task<bool> Exists(Expression<Func<Servicio, bool>> filter)
        {
            return await _context.Servicio.AnyAsync(filter);
        }
        public override async Task<OperationResult> GetAllAsync(Expression<Func<Servicio, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.Servicio.Where(filter).ToListAsync();
            return result;
        }
        public override async Task<List<Servicio>> GetAllAsync()
        {
            return await _context.Servicio.ToListAsync();
        }
        public override async Task<Servicio> GetEntityByIdAsync(short id)
        {
            return await _context.Servicio.FindAsync(id);
        }
        public override async Task<OperationResult> RemoveEntity(short id)
        {
            OperationResult result = new OperationResult();
            try
            {
                await _context.Servicio.Where(e => e.id == id).ExecuteUpdateAsync(setters => setters.SetProperty(e => e.Estado, false));
            }
            catch (Exception ex)
            {

                result.Message = this._configuration["ErrorServicioRepository:RemoveEntity"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public override async Task<OperationResult> SaveEntityAsync(Servicio entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _context.Servicio.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorServicioRepository:SaveEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public override async Task<OperationResult> UpdateEntityAsync(Servicio entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _context.Servicio.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorServicioRepository:UpdateEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
