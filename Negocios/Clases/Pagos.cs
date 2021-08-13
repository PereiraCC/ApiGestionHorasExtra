using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.Clases;

namespace Negocios.Clases
{
   public class Pagos
    {
        private Pago pago = new Pago();
        private FormularioPago frmpago = new FormularioPago();

        public string CrearPago(string email,string motivo, int idtipo, string monto)
        {
            try
            {
                if (pago.obternerFormularioPago(email,motivo).Count !=0)
                {
                    int idpersona = pago.obterneridPago(email,motivo);
                    string res = pago.CrearPago(email, motivo, new PAGOS()
                    {
                        idFormularioPago = idpersona,
                        idTipoPago= idtipo,
                        Monto = monto


                    });

                    if (res.Equals("1"))
                    {
                        return res;
                    }
                    else
                    {
                        return res;
                    }

                }
                else
                {
                    return "Tarea no existe";
                }



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
