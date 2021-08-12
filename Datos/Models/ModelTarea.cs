﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
   public class ModelTarea
    {
        public string email { get; set; }
        public string Nombre { get; set; }

        public int  idSolicitud { get; set; }

        public DateTime entrada { get; set; }

        public DateTime Salida { get; set; }

        public DateTime Fecha { get; set; }

        public int Horas { get; set; }

        public bool Estado { get; set; }


    }
}
