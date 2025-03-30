using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Dtos.HabitacionServiceDto
{
    public class HabitacionSDto : DtoBase
    {
        public string? Numero { get; set; }
        public required string Detalle { get; set; }
        public int? IdEstadoHabitacion { get; set; }
        public int? IdPiso { get; set; }
        public int? IdCategoria { get; set; }
        public bool? Estado { get; set; }
        public int? Capacidad { get; set; }
    }
}
