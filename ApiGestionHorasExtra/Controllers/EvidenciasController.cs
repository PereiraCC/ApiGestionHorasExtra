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
    public class EvidenciasController : ApiController
    {
        // Objeto de clase negocios
        private Evidencias db = new Evidencias();

        public List<EvidenciasFuncionario> GetTareas(string email)
        {
            try
            {
                return db.obtenerListaEvidenciaFuncionario(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/Tareas
        [ResponseType(typeof(ModelEvidencia))]
        public IHttpActionResult PostEvidencias(ModelEvidencia evidencia)
        {
            try
            {
                string resp = db.CrearEvidencia(evidencia);

                if (resp.Equals("1"))
                {
                    return CreatedAtRoute("DefaultApi", new { id = evidencia.Motivo }, evidencia);
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

        [ResponseType(typeof(PERSONAS))]
        [Route("api/Evidencias/AceptarEvidencia", Name = "AceptarEvidencia")]
        public IHttpActionResult AceptarEvidencia(int idEvidencia)
        {
            try
            {
                string resp = db.AceptarEvidencia(idEvidencia);

                if (resp.Equals("1"))
                {
                    return Ok();
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