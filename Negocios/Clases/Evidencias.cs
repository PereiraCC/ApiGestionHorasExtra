using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.Clases;

namespace Negocios.Clases
{
    class Evidencias
    {
        private Evidencia evi = new Datos.Clases.Evidencia();
        private Tarea Tarea = new Tarea();

        public string CrearFormularioAvalado(string motivo, DateTime envio, DateTime horafin, DateTime horaini, string ruta, bool estado)
        {
            try
            {
                if (Tarea.idTarea(motivo) != 0)
                {
                    int idpersona = Tarea.idTarea(motivo);
                    string res = evi.CrearEvidencia(motivo, new EVIDENCIAS()
                    {
                        idSolicitud = idpersona,
                        RutaDocumento=ruta,
                        HoraFinal = horafin,
                        HoraInicial = horaini,
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

        public List<EVIDENCIAS> obtenerListaTareaPorPersona(string email)
        {
            try
            {
                List<EVIDENCIAS> lista = new List<EVIDENCIAS>();
                lista = evi.obternerFormularioEvidencia(email);

                return lista;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
