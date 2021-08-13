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
    public class AvaladosFormularios
    {
        private FormulariosAvalados tarea = new FormulariosAvalados();
        private Tarea persona = new Tarea();

        public string CrearFormularioAvalado(ModelCrearFormularioAvalado formulario)
        {
            try
            {
                if (persona.idTarea(formulario.Motivo)!=0)
                {
                    int idpersona = persona.idTarea(formulario.Motivo);
                    string res = tarea.CrearFormularioAvalado(formulario.Motivo, new FORMULARIOS_AVALADOS()
                    {
                        idSolicitud=idpersona,
                        FechaEnvio= formulario.Envio,
                        Mes= formulario.Mes,
                        TotalHoras = formulario.Hora,
                        RutaArchivo = formulario.Ruta,
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

        public List<FormulariosSolcitudPersona> obtenerFormulariosAvaladosPorPersona(string email)
        {
            try
            {
                List<FormulariosSolcitudPersona> lista = new List<FormulariosSolcitudPersona>();
                lista = tarea.obternerFormularioAvalados(email);

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
