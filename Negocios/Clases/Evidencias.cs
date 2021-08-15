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
    public class Evidencias
    {
        private Evidencia evi = new Datos.Clases.Evidencia();
        private Tarea Tarea = new Tarea();

        public string CrearEvidencia(ModelEvidencia e)
        {
            try
            {
                if (Tarea.idTarea(e.Motivo) != 0)
                {
                    int idSolicitud = Tarea.idTarea(e.Motivo);
                    string res = evi.CrearEvidencia(new EVIDENCIAS()
                    {
                        idSolicitud = idSolicitud,
                        RutaDocumento= e.RutaDocumento,
                        HoraFinal = e.HoraFinal,
                        HoraInicial = e.HoraInicial,
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

        public List<EvidenciasFuncionario> obtenerListaEvidenciaFuncionario(string email)
        {
            try
            {
                return evi.obternerEvidenciasFuncionario(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string AceptarEvidencia(int idEvidencia)
        {
            try
            {
                return evi.aceptarEvidencia(idEvidencia);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
