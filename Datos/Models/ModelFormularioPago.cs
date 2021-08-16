using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Models
{
    public class ModelFormularioPago
    {
        public int idFormularioPago { get; set; }

        public int idFormularioTiempo { get; set; }

        public string Monto { get; set; }

        public string Descripcion { get; set; }

        public bool Estado { get; set; }

    }
}
