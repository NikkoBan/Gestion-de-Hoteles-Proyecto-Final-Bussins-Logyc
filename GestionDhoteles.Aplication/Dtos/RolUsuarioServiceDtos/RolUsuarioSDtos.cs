using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Dtos.RolUsuarioServiceDtos
{
    public class RolUsuarioSDtos : DtoBase
    {
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
    }
}
