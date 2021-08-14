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

        public string CrearTarea(ModelTarea t)
        {
            try
            {
                if(persona.ExistePersona(t.email))
                {
                    int idpersona = persona.getIdPersona(t.email);
                    string res = tarea.CrearTarea(new SOLICITUD_TAREAS()
                    {
                        Entrada=t.entrada,
                        Salida= t.Salida,
                        Estado= false,
                        Fecha= t.Fecha,
                        idPersona= idpersona,
                        Motivo= t.Motivo,
                        TotalHoras=t.Horas
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
