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
    public class PagoFormulario
    {
        private FormularioPago pago = new FormularioPago();
        private FormularioTiempo tiempo = new FormularioTiempo();

        public string CrearFormularioPago(ModelFormularioPago formulario)
        {
            try
            {
                //if (pago.obternerFormularioPago(email, movtivo).Count != 0)
                //{
                    //int idTiempo = tiempo.obterneridFormularioTiempo(email, movtivo);
                    string res = pago.CrearFormularioPago(new FORMULARIOS_PAGO()
                    {
                        idFormularioTiempo = formulario.idFormularioTiempo,
                        Descripcion= formulario.Descripcion,
                        Monto= formulario.Monto,
                        Estado = false
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
                //    return "La persona no existe";
                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ObtenerFormularioPago> obtenerListaFormularioPagoPorPersona(string email)
        {
            try
            {
                List<ObtenerFormularioPago> lista = new List<ObtenerFormularioPago>();
                lista = pago.obternerFormularioPago(email);

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
