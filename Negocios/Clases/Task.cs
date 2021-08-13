using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Clases;
using Datos;
using Datos.Models;

namespace Negocios.Clases
{
    public class NegociosTask
    {
        private Tarea tarea = new Tarea();
        private Persona persona = new Persona();

        public string CrearTarea(string email,DateTime fecha, DateTime salida, DateTime entrada, string movtivo, int hora, bool estado )
        {
            try
            {
                if(persona.ExistePersona(email))
                {
                    int idpersona = persona.getIdPersona(email);
                    string res = tarea.CrearTarea(email,new SOLICITUD_TAREAS()
                    {
                        Entrada=entrada,
                        Salida=salida,
                        Estado= estado,
                        Fecha= fecha,
                        idPersona= idpersona,
                        Motivo=movtivo,
                        TotalHoras=hora
                    });

                    if(res.Equals("1"))
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

        public List<ModelTarea> obtenerListaTareaPorPersona(string email)
        {
            try
            {
                if (Validaciones.validarEmail(email))
                {
                    return tarea.obternerTareaPersona(email);
                } else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
