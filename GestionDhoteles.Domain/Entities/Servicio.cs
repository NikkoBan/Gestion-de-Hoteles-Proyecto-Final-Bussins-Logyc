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
    public sealed class Servicio : BaseEntity<short>
    {
        [Column("IdServicio")]
        [Key]
        public override short id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public object Estado { get; set; }
    }
}
