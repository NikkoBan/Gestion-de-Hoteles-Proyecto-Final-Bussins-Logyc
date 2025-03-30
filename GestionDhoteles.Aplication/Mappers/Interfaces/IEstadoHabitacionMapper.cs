using GestionDhoteles.Aplication.Dtos.EstadoHabitacionServiceDto;
using GestionDhoteles.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Mappers.Interfaces
{
    public interface IEstadoHabitacionMapper : IBaseMapper<SaveEstadoHabitacionSDto, UpdateEstadoHabitacionSDto, RemoveEstadoHabitacionSDto, EstadoHabitacion>
    {
    }
}
