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
    public sealed class Tarifa : BaseEntity<int>
    {
        [Column("IdTarifa")]
        [Key]
        public override int id { get; set; }
        public int IdHabitacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public decimal Descuento { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
