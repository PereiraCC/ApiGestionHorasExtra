using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class ModelEvidencia
    {
        public string RutaDocumento { get; set; }
        public System.DateTime HoraInicial { get; set; }
        public System.DateTime HoraFinal { get; set; }
        public string Motivo { get; set; }

        public bool Estado { get; set; }



    }
}
