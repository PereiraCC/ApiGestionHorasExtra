using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.Clases;

namespace Negocios.Clases
{
    public class AvaladosFormularios
    {
        private FormulariosAvalados tarea = new FormulariosAvalados();
        private Tarea persona = new Tarea();

        public string CrearFormularioAvalado(string motivo, DateTime envio, string mes, int hora, string ruta,bool estado)
        {
            try
            {
                if (persona.idTarea(motivo)!=0)
                {
                    int idpersona = persona.idTarea(motivo);
                    string res = tarea.CrearFormularioAvalado(motivo, new FORMULARIOS_AVALADOS()
                    {
                        idSolicitud=idpersona,
                        FechaEnvio=envio,
                        Mes= mes,
                        TotalHoras = hora,
                        RutaArchivo = ruta,
                        Estado = estado
                        
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

        public List<FormulariosSolcitudPersona> obtenerListaTareaPorPersona(string email)
        {
            try
            {
                List<FormulariosSolcitudPersona> lista = new List<FormulariosSolcitudPersona>();
                lista = tarea.obternerFormularioAvalados(email);

                return lista;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
