using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.Clases;

namespace Negocios.Clases
{
    public class PagoFormulario
    {
        private FormularioPago pago = new FormularioPago();
        private FormularioTiempo tiempo = new FormularioTiempo();

        public string CrearTarea(string email, string movtivo, string monto, string descripcion)
        {
            try
            {
                if (pago.obternerFormularioPago(email, movtivo).Count != 0)
                {
                    int idTiempo = tiempo.obterneridFormularioTiempo(email, movtivo);
                    string res = pago.CrearFormularioPago(email, movtivo, new FORMULARIOS_PAGO()
                    {
                        idFormularioTiempo = idTiempo,
                        Descripcion= descripcion,
                        Monto= monto

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
                    return "La persona no existe";
                }



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<FORMULARIOS_PAGO> obtenerListaTareaPorPersona(string email, string motivo)
        {
            try
            {
                List<FORMULARIOS_PAGO> lista = new List<FORMULARIOS_PAGO>();
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
