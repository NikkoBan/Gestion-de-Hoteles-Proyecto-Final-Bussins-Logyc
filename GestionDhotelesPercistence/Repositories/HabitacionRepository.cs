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
    public class HabitacionRepository : BaseRepository<Habitacion, int>, IHabitacionRepository
    {
        private readonly GestionDhotelesDbContext _context;
        private readonly ILogger<HabitacionRepository> _logger;
        private readonly IConfiguration _configuration;
        public HabitacionRepository(GestionDhotelesDbContext context, ILogger<HabitacionRepository> logger, IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }
        public override async Task<bool> Exists(Expression<Func<Habitacion, bool>> filter)
        {
            return await _context.Habitacion.AnyAsync(filter);
        }
        public override async Task<OperationResult> GetAllAsync(Expression<Func<Habitacion, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.Habitacion.Where(filter).ToListAsync();
            return result;
        }
        public override async Task<List<Habitacion>> GetAllAsync()
        {
            return await _context. Habitacion.ToListAsync();
        }
        public override async Task<Habitacion> GetEntityByIdAsync(int id)
        {
            return await _context.Habitacion.FindAsync(id);
        }
        public override async Task<OperationResult> RemoveEntity(int id)
        {
            OperationResult result = new OperationResult();
            try
            {
                await _context.Habitacion.Where(e => e.id == id).ExecuteUpdateAsync(setters => setters.SetProperty(e => e.Estado, false));
            }
            catch (Exception ex)
            {

                result.Message = this._configuration["ErrorHabitacionRepository:RemoveEntity"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public override async Task<OperationResult> SaveEntityAsync(Habitacion entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _context.Habitacion.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorHabitacionRepository:SaveEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public override async Task<OperationResult> UpdateEntityAsync(Habitacion entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _context.Habitacion.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorHabitacionRepository:UpdateEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
