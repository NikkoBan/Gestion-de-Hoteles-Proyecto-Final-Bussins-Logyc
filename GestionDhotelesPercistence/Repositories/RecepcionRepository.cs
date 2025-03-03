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
    public class RecepcionRepository : BaseRepository<Recepcion, int>, IRecepcionRepository
    {
        private readonly GestionDhotelesDbContext _context;
        private readonly ILogger<RecepcionRepository> _logger;
        private readonly IConfiguration _configuration;
        public RecepcionRepository(GestionDhotelesDbContext context, ILogger<RecepcionRepository> logger, IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }
        public override async Task<bool> Exists(Expression<Func<Recepcion, bool>> filter)
        {
            return await _context.Recepcion.AnyAsync(filter);
        }
        public override async Task<OperationResult> GetAllAsync(Expression<Func<Recepcion, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.Recepcion.Where(filter).ToListAsync();
            return result;
        }
        public override async Task<List<Recepcion>> GetAllAsync()
        {
            return await _context.Recepcion.ToListAsync();
        }
        public override async Task<Recepcion> GetEntityByIdAsync(int id)
        {
            return await _context.Recepcion.FindAsync(id);
        }
        public override async Task<OperationResult> RemoveEntity(int id)
        {
            OperationResult result = new OperationResult();
            try
            {
                await _context.Recepcion.Where(e => e.id == id).ExecuteUpdateAsync(setters => setters.SetProperty(e => e.Estado, false));
            }
            catch (Exception ex)
            {

                result.Message = this._configuration["ErrorRecepcionRepository:RemoveEntity"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public override async Task<OperationResult> SaveEntityAsync(Recepcion entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _context.Recepcion.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorRecepcionRepository:SaveEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public override async Task<OperationResult> UpdateEntityAsync(Recepcion entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _context.Recepcion.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Message = this._configuration["ErrorRecepcionRepository:UpdateEntityAsync"];
                result.Success = false;
                this._logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
