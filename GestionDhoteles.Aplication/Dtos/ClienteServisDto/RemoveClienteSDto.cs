using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Dtos.ClienteServisDto
{
    public class RemoveClienteSDto : DtoBase
    {
            public int IdCliente { get; set; }
            public bool Borrado { get; set; }
    }
}

