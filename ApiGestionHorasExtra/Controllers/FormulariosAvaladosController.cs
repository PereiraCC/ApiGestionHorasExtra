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
    public class FormulariosAvaladosController : ApiController
    {
        // Objeto de clase negocios
        private AvaladosFormularios db = new AvaladosFormularios();

        public List<FormulariosSolcitudPersona> GetFormulariosAvalados(string email)
        {
            try
            {
                return db.obtenerFormulariosAvaladosPorPersona(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST: api/Tareas
        [ResponseType(typeof(ModelCrearFormularioAvalado))]
        public IHttpActionResult PostTareas(ModelCrearFormularioAvalado formulario)
        {
            try
            {
                string resp = db.CrearFormularioAvalado(formulario);

                if (resp.Equals("1"))
                {
                    return CreatedAtRoute("DefaultApi", new { id = formulario.Motivo }, formulario);
                }
                else if (resp.Equals("Tarea no existe"))
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

        [HttpGet]
        [ResponseType(typeof(PERSONAS))]
        [Route("api/FormulariosAvalados/obtenerFormulariosAvaladosPendientes", Name = "obtenerFormulariosAvaladosPendientes")]
        public List<FormulariosSolcitudPersona> obtenerFormulariosAvaladosPendientes(string email)
        {
            try
            {
                return db.obtenerFormulariosAvaladosPendientes(email);
            }
            catch (Exception ex)
            {
                throw ex;
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