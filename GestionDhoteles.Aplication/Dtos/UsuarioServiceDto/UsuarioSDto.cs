using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Dtos
{
    public class UsuarioSDtos : DtoBase
    {
        public string? NombreCompleto { get; set; }
        public string? Correo { get; set; }
        public int? IdRolUsuario { get; set; }
        public string? Clave { get; set; }
        public bool? Estado { get; set; }
    }
}
