using GestionDhoteles.Aplication.Dtos.EstadoHabitacionSDto;
using GestionDhoteles.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Dtos.EstadoHabitacionServiceDto
{
    public class SaveEstadoHabitacionSDto : EstadoHabitacionSDto
    {
        public string? Descripcion { get; internal set; }
        public object Usuario { get; internal set; }
        public object Estado { get; internal set; }
        public object Fecha { get; internal set; }
    }
}
