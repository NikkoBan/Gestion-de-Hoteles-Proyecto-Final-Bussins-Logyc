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
    public sealed class Usuario : BaseEntity<int>
    {
        [Column("IdUsuario")]
        [Key]
        public override int id { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public int? IdRolUsuario { get; set; }
        public string? Clave { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }

    }
}
