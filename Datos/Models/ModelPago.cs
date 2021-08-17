using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class ModelPago
    {
        public int idPago { get; set; }

        public int idFormularioPago { get; set; }

        public string Monto { get; set; }

        public string TipoPago { get; set; }

        public bool Estado { get; set; }

    }
}
