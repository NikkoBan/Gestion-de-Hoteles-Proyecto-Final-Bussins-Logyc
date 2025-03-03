using GestionDhoteles.Domain.Base;
using GestionDhoteles.Domain.Entities;
using GestionDhotelesPercistence.Base;
using GestionDhotelesPercistence.Context;
using GestionDhotelesPercistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhotelesPercistence.Repositories
{
    public class PisoRepository : BaseRepository<Piso, int>, IPisoRepository
    {
        private readonly GestionDhotelesDbContext _context;
        private readonly ILogger<PisoRepository> _logger;
        private readonly IConfiguration _configuration;
        public PisoRepository(GestionDhotelesDbContext context, ILogger<PisoRepository> logger, IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }
        public override async Task<bool> Exists(Expression<Func<Piso, bool>> filter)
        {
            return await _context.Piso.AnyAsync(filter);
        }
        public override async Task<OperationResult> GetAllAsync(Expression<Func<Piso, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.Piso.Where(filter).ToListAsync();
            return result;
        }
        public override async Task<List<Piso>> GetAllAsync()
        {
            return await _context.Piso.ToListAsync();
        }
        public override async Task<Piso> GetEntityByIdAsync(int id)
        {
            return await _context.Piso.FindAsync(id);
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

                result.Message = this._configuration["ErrorPisoRepository:RemoveEntity"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public override async Task<OperationResult> SaveEntityAsync(Piso entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _context.Piso.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorPisoRepository:SaveEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public override async Task<OperationResult> UpdateEntityAsync(Piso entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _context.Piso.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorPisoRepository:UpdateEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
