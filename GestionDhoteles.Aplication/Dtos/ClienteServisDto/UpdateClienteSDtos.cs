using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Dtos.ClienteServisDto
{
    public class UpdateClienteSDto
    {
        public int IdCliente { get; set; }
        public object Estado { get; internal set; }
        public string? NombreCompleto { get; internal set; }
        public string? Documento { get; internal set; }
        public string? TipoDocumento { get; internal set; }
        public string? Correo { get; internal set; }
        public object Fecha { get; internal set; }
        public object Usuario { get; internal set; }
    }
}
