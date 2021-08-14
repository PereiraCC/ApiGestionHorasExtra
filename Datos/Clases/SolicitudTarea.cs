using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Models;


namespace Datos.Clases
{
    public class SolicitudTarea
    {
        private HorasExtraEntities entities;
        public Persona persona = new Persona();

        public SolicitudTarea()
        {
            entities = new HorasExtraEntities();

        }

        public int getidSolicitud(string motivo)
        {
            try
            {
                var query = from c in entities.FORMULARIO_SOLICITUD_TAREAS
                            where c.Motivo == motivo && c.Estado == false
                            select c;

                List<FORMULARIO_SOLICITUD_TAREAS> temp = query.ToList<FORMULARIO_SOLICITUD_TAREAS>();

                foreach (FORMULARIO_SOLICITUD_TAREAS t in temp)
                {
                   if(t.Motivo.Equals(motivo) && t.Estado == false)
                   {
                       return t.idFormularioSolicitud;
                   }
                }

                return 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string CrearTarea(FORMULARIO_SOLICITUD_TAREAS tarea)
        {
            try
            {
                try
                {
                    entities.FORMULARIO_SOLICITUD_TAREAS.Add(tarea);
                    int res = entities.SaveChanges();
                    if (res == 1)
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
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //public bool ExisteTareaPersona(string email)
        //{
        //    try
        //    {
        //        var query = from c in entities.TareaPersona
        //                    where c.Email == email
        //                    select c;
        //        List<TareaPersona> tarea = query.ToList<TareaPersona>();

        //        if (tarea.Count == 0)
        //        {
        //            return false;
        //        }
        //        {
        //            return true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public List<ModelTarea> obternerSolicitudes()
        {
            try
            {

                    List<ModelTarea> model = new List<ModelTarea>();
                    var query = from c in entities.SolicitudTareaPersona
                                where c.Estado == false
                                select c;
                    List<SolicitudTareaPersona> tarea = query.ToList<SolicitudTareaPersona>();

                    foreach (SolicitudTareaPersona temp in tarea)
                    {
                        ModelTarea r = new ModelTarea();
                        r.email = temp.Email;
                        r.Motivo = temp.Motivo;
                        r.idSolicitud = temp.idFormularioSolicitud;
                        r.entrada = temp.Entrada;
                        r.Salida = temp.Salida;
                        r.Fecha = temp.Fecha;
                        r.Horas = temp.TotalHoras;
                        r.Estado = temp.Estado;

                        model.Add(r);

                    }

                    return model;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ModelTarea obternerUnaSolicitud(int idSolicitud)
        {
            try
            {
                var query = from c in entities.SolicitudTareaPersona
                            where c.Estado == false && c.idFormularioSolicitud == idSolicitud
                            select c;

                List<SolicitudTareaPersona> tarea = query.ToList<SolicitudTareaPersona>();

                foreach (SolicitudTareaPersona temp in tarea)
                {
                    if(temp.idFormularioSolicitud == idSolicitud && temp.Estado == false)
                    {
                        return new ModelTarea()
                        {
                            email = temp.Email,
                            Motivo = temp.Motivo,
                            entrada = temp.Entrada,
                            Salida = temp.Salida,
                            Fecha = temp.Fecha,
                            Horas = temp.TotalHoras,
                            Estado = false
                        };
                    }

                }

                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string actualizarSolicitud(int idSolicitud)
        {

            try
            {
                FORMULARIO_SOLICITUD_TAREAS usu = entities.FORMULARIO_SOLICITUD_TAREAS.First<FORMULARIO_SOLICITUD_TAREAS>(x => x.idFormularioSolicitud == idSolicitud);
                usu.Estado = true;

                entities.Entry(usu).State = EntityState.Modified;

                int res = entities.SaveChanges();
                if (res == 1)
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

    }

}
