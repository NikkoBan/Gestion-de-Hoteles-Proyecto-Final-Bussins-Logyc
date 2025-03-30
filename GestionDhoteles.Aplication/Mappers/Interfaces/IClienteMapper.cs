using GestionDhoteles.Aplication.Dtos.ClienteServisDto;
using GestionDhoteles.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Mappers.Interfaces
{
    public interface IClienteMapper : IBaseMapper<SaveClienteSDto, UpdateClienteSDto, RemoveClienteSDto, Cliente>
    {
    }
}
