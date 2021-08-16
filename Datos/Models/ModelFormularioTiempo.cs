using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    public class ModelFormularioTiempo
    {
        public int  idFormularioTiempo { get; set; }

        public int idFormularioAvalado { get; set; }

        public int Horas { get; set; }

        public string Quincena { get; set; }

        public bool Estado { get; set; }


    }
}
