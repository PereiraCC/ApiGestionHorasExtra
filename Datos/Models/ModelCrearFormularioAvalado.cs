using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class ModelCrearFormularioAvalado
    {
        public string Motivo { get; set; }
        public DateTime Envio { get; set; }
        public string Mes { get; set; }
        public int Hora { get; set; }
        public string Ruta { get; set; }
    }
}
