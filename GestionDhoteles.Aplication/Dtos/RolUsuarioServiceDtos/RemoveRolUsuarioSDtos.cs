using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Dtos.RolUsuarioServiceDtos
{
    public class RemoveRolUsuarioSDtos : DtoBase
    {
        public int IdRolUsuario { get; set; }
        public bool Borrado { get; set; }
    }
}
