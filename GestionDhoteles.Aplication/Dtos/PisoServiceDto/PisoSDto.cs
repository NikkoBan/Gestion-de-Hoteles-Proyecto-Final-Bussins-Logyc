﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDhoteles.Aplication.Dtos.PisoServiceDto
{
    public class PisoSDto : DtoBase
    {
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }
    }
}
