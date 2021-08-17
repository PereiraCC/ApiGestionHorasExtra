using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.Clases;
using Datos.Models;

namespace Negocios.Clases
{
   public class Pagos
    {
        private Pago pago = new Pago();
        private FormularioPago frmpago = new FormularioPago();

        public string CrearPago(ModelPago p)
        {
            try
            {
                //if (pago.obternerFormularioPago(email,motivo).Count !=0)
                //{
                    int idTipoPago = pago.obternerIdTipoPago(p.TipoPago);
                    string res = pago.CrearPago(new PAGOS()
                    {
                        idFormularioPago = p.idFormularioPago,
                        idTipoPago= idTipoPago,
                        Monto = p.Monto,
                        Estado = true
                    });

                    if (res.Equals("1"))
                    {
                        return res;
                    }
                    else
                    {
                        return res;
                    }

                //}
                //else
                //{
                //    return "Tarea no existe";
                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PAGOS> obtenerListaTareaPorPersona(string email, string motivo)
        {
            try
            {
                List<PAGOS> lista = new List<PAGOS>();
                lista = pago.obternerFormularioPago(email, motivo);

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
