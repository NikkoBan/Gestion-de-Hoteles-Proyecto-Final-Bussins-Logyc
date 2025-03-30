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
        public object Creador { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioMod { get; set; }
        public bool Borrado { get; set; }
        public int Borrador { get; set; }
        public object EstadoYFecha { get; set; }
        public object CreadorforU { get; set; }
    }
}
