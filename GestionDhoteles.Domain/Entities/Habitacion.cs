using GestionDhoteles.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Domain.Entities
{
    public sealed class Habitacion : BaseEntity<int>
    {
        [Column("IdHabitacion")]
        [Key]
        public override int id { get; set; }
        public string? Numero { get; set; }
        public string? Detalle { get; set; }
        public decimal? Precio { get; set; }
        public int? IdEstadoHabitacion { get; set; }
        public int? IdPiso { get; set; }
        public int? IdCategoria { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }

    }
}
