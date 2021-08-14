using Datos;
using Datos.Models;
using Negocios.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace ApiHorasExtra.Controllers
{
    public class SolicitudController : ApiController
    {
        // Objeto de clase negocios
        private SolicitudTareaNegocio db = new SolicitudTareaNegocio();

        public List<ModelTarea> GetSolicitud()
        {
            try
            {
                return db.obtenerListaSolicitudes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/Tareas
        [ResponseType(typeof(ModelTarea))]
        public IHttpActionResult PostSolicitud(ModelTarea tarea)
        {
            try
            {
                string resp = db.CrearTarea(tarea);

                if (resp.Equals("1"))
                {
                    return CreatedAtRoute("DefaultApi", new { id = tarea.Motivo }, tarea);
                }
                else if (resp.Equals("La persona no existe"))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception(resp);
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[ResponseType(typeof(ModelTarea))]
        [Route("api/Solicitud/AceptarSolicitud", Name = "AceptarSolicitud")]
        public IHttpActionResult AceptarSolicitud(string motivo)
        {
            try
            {
                string resp = db.AceptarSolicitud(motivo);

                if (resp.Equals("1"))
                {
                    return Ok();
                }
                else if (resp.Equals("La persona no existe"))
                {
                    return NotFound();
                }
                else
                {
                    throw new Exception(resp);
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[ResponseType(typeof(PERSONAS))]
        //[Route("api/Personas/SingOut", Name = "CerrarSesion")]
        //public IHttpActionResult CerrarSesion(PersonaModel usuarios)
        //{
        //    try
        //    {
        //        string resp = db.CerrarSesion(usuarios.email);

        //        if (resp.Equals("El usuario no existe"))
        //        {
        //            return NotFound();
        //        }
        //        else if (resp.Equals("0"))
        //        {
        //            throw new Exception("Error al momento de cerrar sesion");
        //        }
        //        else if (resp.Equals("1"))
        //        {
        //            return Ok();
        //        }
        //        else
        //        {
        //            throw new Exception(resp);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}
    }
}