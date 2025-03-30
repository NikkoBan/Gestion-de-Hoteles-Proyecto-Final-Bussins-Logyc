using GestionDhoteles.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Base
{
    public abstract class Person<Ttype> : BaseEntity<Ttype>
    {
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
    }
}
