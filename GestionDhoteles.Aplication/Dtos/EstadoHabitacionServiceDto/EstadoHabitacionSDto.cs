using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Dtos.EstadoHabitacionSDto
{
    public class EstadoHabitacionSDto : DtoBase
    {
        public required string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
