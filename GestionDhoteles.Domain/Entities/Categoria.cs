using GestionDhoteles.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Domain.Entities
{
    public sealed class Categoria : BaseEntity<int>
    {
        [Column ("IdCategoria")]
        [Key]
        public override int id { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
        public int IdServicio { get; set; }
        public DateTime? FechaCreacion { get; set; }

    }
}
