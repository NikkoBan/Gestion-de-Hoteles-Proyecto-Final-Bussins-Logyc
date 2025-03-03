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
    public class EstadoHabitacionRepository : BaseRepository<EstadoHabitacion, int>, IEstadoHabitacionRepository
    {
        private readonly GestionDhotelesDbContext _context;
        private readonly ILogger<EstadoHabitacionRepository> _logger;
        private readonly IConfiguration _configuration;
        public EstadoHabitacionRepository(GestionDhotelesDbContext context, ILogger<EstadoHabitacionRepository> logger, IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }
        public override async Task<bool> Exists(Expression<Func<EstadoHabitacion, bool>> filter)
        {
            return await _context.EstadoHabitacion.AnyAsync(filter);
        }
        public override async Task<OperationResult> GetAllAsync(Expression<Func<EstadoHabitacion, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.EstadoHabitacion.Where(filter).ToListAsync();
            return result;
        }
        public override async Task<List<EstadoHabitacion>> GetAllAsync()
        {
            return await _context.EstadoHabitacion.ToListAsync();
        }
        public override async Task<EstadoHabitacion> GetEntityByIdAsync(int id)
        {
            return await _context.EstadoHabitacion.FindAsync(id);
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
        public override async Task<OperationResult> SaveEntityAsync(EstadoHabitacion entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _context.EstadoHabitacion.Add(entity);
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
        public override async Task<OperationResult> UpdateEntityAsync(EstadoHabitacion entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _context.EstadoHabitacion.Update(entity);
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
