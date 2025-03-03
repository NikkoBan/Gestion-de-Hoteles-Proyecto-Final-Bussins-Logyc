using GestionDhoteles.Domain.Entities;
using GestionDhotelesPercistence.Base;

namespace GestionDhotelesPercistence.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario,int>
    {
    }
}
