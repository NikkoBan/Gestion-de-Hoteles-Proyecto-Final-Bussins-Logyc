using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Dtos.UsuarioServiceDto
{
    public class RemoveUsuarioSDtos : DtoBase
    {
        public int IdUsuario { get; set; }
        public bool Borrado { get; set; }
    }
}
