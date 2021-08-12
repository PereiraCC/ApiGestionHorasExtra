using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;


namespace Datos.Clases
{
    public class Tarea
    {
        private HorasExtraEntities entities;
        public Persona persona = new Persona();

        public Tarea()
        {
            entities = new HorasExtraEntities();
            
        }

        public int idTarea(string motivo)
        {
            try
            {
                var query = from c in entities.TareaPersona
                            where c.Motivo == motivo
                            select c;

                List<TareaPersona> temp = query.ToList<TareaPersona>();

              
                    int id = 0;
                    foreach(TareaPersona t in temp)
                    {
                        id = t.idSolicitud;
                    }
                    return id;
               

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string CrearTarea(string email, SOLICITUD_TAREAS tarea)
        {
            try
            {
                if (persona.ExistePersona(email))
                {                    
                    try
                    {
                       entities.SOLICITUD_TAREAS.Add(tarea);
                        int res = entities.SaveChanges();
                        if (res==1)
                        {
                            return "1";
                        }
                        else
                        {
                            return "0";
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }

                }
                else
                {
                    return "Persona no existe";

                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool ExisteTareaPersona(string email)
        {
            try
            {
                var query = from c in entities.TareaPersona
                            where c.Email == email
                            select c;
                List<TareaPersona> tarea = query.ToList<TareaPersona>();

                if (tarea.Count==0)
                {
                    return false;
                }
                {
                    return true;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



       
        public List<ModelTarea> obternerTareaPersona(string email)
        {
            try
            {
                if (ExisteTareaPersona(email))
                {
                    List<ModelTarea> model = new List<ModelTarea>();
                    var query = from c in entities.TareaPersona
                                where c.Email == email
                                select c;
                    List<TareaPersona> tarea = query.ToList<TareaPersona>();

                    foreach (TareaPersona temp in tarea)
                    {
                        ModelTarea r = new ModelTarea();
                        r.email = temp.Email;
                        r.Nombre = temp.NombreCompleto;
                        r.idSolicitud = temp.idSolicitud;
                        r.entrada = temp.Entrada;
                        r.Salida = temp.Salida;
                        r.Fecha = temp.Fecha;
                        r.Horas = temp.TotalHoras;
                        r.Estado = temp.Estado;

                        model.Add(r);

                    }

                    return model;
                }
                else
                {
                    List<ModelTarea> model = new List<ModelTarea>();

                    return model;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
