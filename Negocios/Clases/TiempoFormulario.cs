using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.Clases;

namespace Negocios.Clases
{
    public class TiempoFormulario
    {
        private FormularioTiempo tiempo = new FormularioTiempo();

        public string CrearFormularioTiempo(ModelFormularioTiempo formulario)
        {
            try
            {
                //if (tiempo.obternerFormularioTiempo(email,movtivo).Count !=0)
                //{
                    //int idpersona = tiempo.idFormularioAvalado(email,movtivo);
                    string res = tiempo.CrearFormularioTiempo(new FORMULARIOS_TIEMPO()
                    {
                       idFormularioAvalado = formulario.idFormularioAvalado,
                       HorasValidas = formulario.Horas,
                       QUINCENA = formulario.Quincena,
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

        public List<FORMULARIOS_TIEMPO> obtenerListaTareaPorPersona(string email, string motivo)
        {
            try
            {
                List<FORMULARIOS_TIEMPO> lista = new List<FORMULARIOS_TIEMPO>();
                lista = tiempo.obternerFormularioTiempo(email,motivo);

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
