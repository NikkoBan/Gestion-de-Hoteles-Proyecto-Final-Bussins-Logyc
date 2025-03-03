using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Domain.Base
{
    public abstract class BaseEntity<Ttype>
    {
        public abstract Ttype id { get; set; }
    }
}
