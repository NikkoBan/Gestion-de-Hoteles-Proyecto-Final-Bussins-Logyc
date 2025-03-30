using GestionDhoteles.Aplication.Dtos.HabitacionServiceDto;
using GestionDhoteles.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Mappers.Interfaces
{
    public interface IHabitacionMapper : IBaseMapper<SaveHabitacionSDto, UpdateHabitacionSDto, RemoveHabitacionSDto, Habitacion>
    {
    }
}
