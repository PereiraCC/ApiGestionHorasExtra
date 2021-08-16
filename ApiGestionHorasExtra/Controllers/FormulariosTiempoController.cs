using Datos;
using Datos.Clases;
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
    public class FormulariosTiempoController : ApiController
    {
        // Objeto de clase negocios
        private TiempoFormulario db = new TiempoFormulario();

        //public List<FormulariosSolcitudPersona> GetFormulariosAvalados(string email)
        //{
        //    try
        //    {
        //        return db.obtenerFormulariosAvaladosPorPersona(email);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        // POST: api/Tareas
        [ResponseType(typeof(ModelCrearFormularioAvalado))]
        public IHttpActionResult PostTareas(ModelFormularioTiempo formulario)
        {
            try
            {
                string resp = db.CrearFormularioTiempo(formulario);

                if (resp.Equals("1"))
                {
                    return CreatedAtRoute("DefaultApi", new { id = formulario.idFormularioTiempo }, formulario);
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

        //[ResponseType(typeof(PERSONAS))]
        //[Route("api/Personas/Login", Name = "InicioSesion")]
        //public IHttpActionResult InicioSesion(PersonaModel p)
        //{
        //    try
        //    {
        //        string resp = db.ValidarInicioSesion(p);
        //        string[] data = resp.Split(',');

        //        if (data[1].Equals("El usuario no existe"))
        //        {
        //            return NotFound();
        //        }
        //        else if (data[1].Equals("Usuario y/o contraseña incorrectos."))
        //        {
        //            throw new Exception(data[1]);
        //        }
        //        else if (data[0].Equals("1"))
        //        {
        //            return Ok(data[1]);
        //        }
        //        else
        //        {
        //            throw new Exception(data[1]);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}

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