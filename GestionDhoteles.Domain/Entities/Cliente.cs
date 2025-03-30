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
    public sealed class Cliente : BaseEntity<int>
    {
        [Column("IdCliente")]
        [Key]
        public override int id { get; set; }
        public string? TipoDocumento { get; set; }
        public string? Documento { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public object UsuarioMod { get; set; }
        public object FechaModificacion { get; set; }
        public object EstadoYFecha { get; set; }
        public bool Borrado { get; set; }
        public int CreadorPorU { get; set; }
    }
}
