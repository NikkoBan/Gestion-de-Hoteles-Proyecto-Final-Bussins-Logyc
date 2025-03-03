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
    public class TarifaRepository : BaseRepository<Tarifa, int>, ITarifaRepository
    {
        private readonly GestionDhotelesDbContext _context;
        private readonly ILogger<TarifaRepository> _logger;
        private readonly IConfiguration _configuration;
        public TarifaRepository(GestionDhotelesDbContext context, ILogger<TarifaRepository> logger, IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }
        public override async Task<bool> Exists(Expression<Func<Tarifa, bool>> filter)
        {
            return await _context.Tarifa.AnyAsync(filter);
        }
        public override async Task<OperationResult> GetAllAsync(Expression<Func<Tarifa, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.Tarifa.Where(filter).ToListAsync();
            return result;
        }
        public override async Task<List<Tarifa>> GetAllAsync()
        {
            return await _context.Tarifa.ToListAsync();
        }
        public override async Task<Tarifa> GetEntityByIdAsync(int id)
        {
            return await _context.Tarifa.FindAsync(id);
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

                result.Message = this._configuration["ErrorCategoriaRepository:RemoveEntity"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public override async Task<OperationResult> SaveEntityAsync(Tarifa entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _context.Tarifa.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorCategoriaRepository:SaveEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public override async Task<OperationResult> UpdateEntityAsync(Tarifa entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _context.Tarifa.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorCategoriaRepository:UpdateEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
