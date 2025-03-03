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
    public class CategoriaRepository : BaseRepository<Categoria,int>, ICategoriasRepository
    {
        private readonly GestionDhotelesDbContext _context;
        private readonly ILogger<CategoriaRepository> _logger;
        private readonly IConfiguration _configuration;
        public CategoriaRepository(GestionDhotelesDbContext context, ILogger<CategoriaRepository> logger, IConfiguration configuration) : base(context)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }
        public override async Task<bool> Exists(Expression<Func<Categoria, bool>> filter)
        {
            return await _context.Categoria.AnyAsync(filter);
        }
        public override async Task<OperationResult> GetAllAsync(Expression<Func<Categoria, bool>> filter)
        {
            OperationResult result = new OperationResult();
            result.Data = await _context.Categoria.Where(filter).ToListAsync();
            return result;
        }
        public override async Task<List<Categoria>> GetAllAsync()
        {
            return await _context.Categoria.ToListAsync();
        }
        public override async Task<Categoria> GetEntityByIdAsync(int id)
        {
            return await _context.Categoria.FindAsync(id);
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
        public override async Task<OperationResult> SaveEntityAsync(Categoria entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _context.Categoria.Add(entity);
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
        public override async Task<OperationResult> UpdateEntityAsync(Categoria entity)
        {
            OperationResult result = new OperationResult();
            try
            {
                _context.Categoria.Update(entity);
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
