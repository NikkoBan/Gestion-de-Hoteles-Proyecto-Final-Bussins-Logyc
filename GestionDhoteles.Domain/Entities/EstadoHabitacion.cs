using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionDhoteles.Domain.Base;

namespace GestionDhoteles.Domain.Entities
{
    public sealed class EstadoHabitacion : BaseEntity<int>
    {
        [Column("IdEstadoHabitacion")]
        [Key]
        public override int id { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
