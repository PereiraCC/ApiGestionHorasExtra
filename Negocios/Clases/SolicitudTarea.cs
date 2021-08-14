using Datos;
using Datos.Clases;
using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios.Clases
{
    public class SolicitudTareaNegocio
    {
        private SolicitudTarea tarea = new SolicitudTarea();
        private Tarea BdTarea = new Tarea();

        private Persona persona = new Persona();

        public string CrearTarea(ModelTarea t)
        {
            try
            {
                if (persona.ExistePersona(t.email))
                {
                    int idpersona = persona.getIdPersona(t.email);
                    string res = tarea.CrearTarea(new FORMULARIO_SOLICITUD_TAREAS()
                    {
                        Entrada = t.entrada,
                        Salida = t.Salida,
                        Estado = false,
                        Fecha = t.Fecha,
                        idPersona = idpersona,
                        Motivo = t.Motivo,
                        TotalHoras = t.Horas
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

        public List<ModelTarea> obtenerListaSolicitudes()
        {
            try
            {
                 return tarea.obternerSolicitudes();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string AceptarSolicitud(string motivo)
        {
            try
            {
                int idSolicitud = tarea.getidSolicitud(motivo);
                ModelTarea t = tarea.obternerUnaSolicitud(idSolicitud);
                int idpersona = persona.getIdPersona(t.email);
                string res = BdTarea.CrearTarea(new SOLICITUD_TAREAS()
                {
                    Entrada = t.entrada,
                    Salida = t.Salida,
                    Estado = false,
                    Fecha = t.Fecha,
                    idPersona = idpersona,
                    Motivo = t.Motivo,
                    TotalHoras = t.Horas
                });

                if (res.Equals("1"))
                {
                    res = tarea.actualizarSolicitud(idSolicitud);
                    return res;
                }
                else
                {
                    return res;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
