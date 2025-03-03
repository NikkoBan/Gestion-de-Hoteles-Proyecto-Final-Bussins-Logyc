using GestionDhoteles.Domain.Entities;
using GestionDhotelesPercistence.Base;

namespace GestionDhotelesPercistence.Interfaces
{
    public interface IClientesRepository : IBaseRepository<Cliente, int>
    {
    }
}
