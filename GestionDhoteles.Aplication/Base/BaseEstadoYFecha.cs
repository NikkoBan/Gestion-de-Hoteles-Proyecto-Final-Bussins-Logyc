using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Base
{
    [Owned]
    public sealed class BaseEstadoYFecha
    {
        [Column("Estado")]
        public bool? Estado { get; set; }

        [Column("FechaCreacion")]
        public DateTime? FechaCreacion { get; set; }
    }
}
