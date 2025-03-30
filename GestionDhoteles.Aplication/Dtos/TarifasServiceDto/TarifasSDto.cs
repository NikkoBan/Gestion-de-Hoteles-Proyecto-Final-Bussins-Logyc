using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Dtos.TarifasServiceDto
{
    public class TarifasSDto : DtoBase
    {
        public int? IdCategoria { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public decimal? PrecioPorNoche { get; set; }
        public decimal? Descuento { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
    }
}
