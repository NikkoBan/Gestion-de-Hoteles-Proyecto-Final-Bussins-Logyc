using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Dtos.EstadoHabitacionServiceDto
{
    public class UpdateEstadoHabitacionSDto
    {
        public int IdEstadoHabitacion { get; set; }
        public string Descripcion { get; internal set; }
        public bool Estado { get; internal set; }
        public int Usuario { get; internal set; }
    }
}
