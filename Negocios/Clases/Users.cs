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
    public class Users
    {
        private Persona usuario = new Persona();
        private InicioSesion inicioSesion = new InicioSesion();

        private string ValidarPersonaRegistro(PersonaModel persona)
        {
            try
            {
                if (!Validaciones.ValidarNulos(persona.nombreCompleto) || !Validaciones.ValidarNulos(persona.email) || !Validaciones.ValidarNulos(persona.pass) || !Validaciones.ValidarNulos(persona.departamento))
                {
                    if (Validaciones.validarTexto(persona.nombreCompleto))
                    {
                        if (!Validaciones.validarKeyWords(persona.nombreCompleto) || !Validaciones.validarKeyWords(persona.email) || !Validaciones.validarKeyWords(persona.pass) || !Validaciones.validarKeyWords(persona.departamento))
                        {
                            if (Validaciones.validarEmail(persona.email))
                            {
                                if (persona.pass.Length >= 6)
                                {
                                    return "1";
                                }
                                else
                                {
                                    return "La contraseña no contiene una cantidad de caracteres validos.";
                                }
                            }
                            else
                            {
                                return "El correo tiene un formato incorrecto.";
                            }
                        }
                        else
                        {
                            return "Los datos contienen informacion invalida.";
                        }
                    }
                    else
                    {
                        return "El campo Nombre Completo no deben contener numeros.";
                    }
                }
                else
                {
                    return "Todos datos son requeridos.";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ValidarPersonaDatosInicioSesion(PersonaModel persona)
        {
            try
            {
                if (!Validaciones.ValidarNulos(persona.email) || !Validaciones.ValidarNulos(persona.pass))
                {
                    if (Validaciones.validarEmail(persona.email))
                    {
                        if (!Validaciones.validarKeyWords(persona.email) || !Validaciones.validarKeyWords(persona.pass))
                        {
                            if (persona.pass.Length >= 6)
                            {
                                return "1";
                            }
                            else
                            {
                                return "La contraseña no contiene una cantidad de caracteres validos.";
                            }
                        }
                        else
                        {
                            return "Los datos contienen informacion invalida.";
                        }
                    }
                    else
                    {
                        return "El correo no tiene un formato valido.";
                    }
                }
                else
                {
                    return "El campo de email y la contraseña es Obligatorio";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string ValidarUsuarioInicioSesion(string email)
        {
            try
            {
                if (!Validaciones.ValidarNulos(email))
                {
                    if (Validaciones.validarEmail(email))
                    {
                        if (!Validaciones.validarKeyWords(email))
                        {
                            return "1";
                        }
                        else
                        {
                            return "Los datos contienen informacion invalida.";
                        }
                    }
                    else
                    {
                        return "La email tiene un formato invalido";
                    }
                }
                else
                {
                    return "El campo de email es Obligatorio";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string crearPersona(PersonaModel persona)
        {
            try
            {
                string resp = ValidarPersonaRegistro(persona);
                if (resp.Equals("1"))
                {
                    if (!usuario.ExistePersona(persona.email))
                    {
                        int res = usuario.crearPersona(persona);

                        if (res == 1)
                        {
                            return "1";
                        }
                        else
                        {
                            return "0";
                        }
                    }
                    else
                    {
                        return "Usuario Existe";
                    }
                }
                else
                {
                    return resp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ValidarInicioSesion(PersonaModel persona)
        {
            try
            {
                string resp = ValidarPersonaDatosInicioSesion(persona);
                if (resp.Equals("1"))
                {

                    string clave = inicioSesion.ValidarInicioSesion(persona);
                    if (clave.Equals("1"))
                    {
                        PersonaModel p = usuario.BuscarPersona(persona.email);
                        return "1," + p.nombreCompleto + "," + p.email + "," + p.departamento;
                    }
                    else if (clave.Equals("Datos incorrectos"))
                    {
                        return "0,Usuario y/o contraseña incorrectos.";
                    }
                    else
                    {
                        return "0,El usuario no existe";
                    }
                }
                else
                {
                    return "0," + resp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CerrarSesion(string email)
        {
            try
            {
                string resp = ValidarUsuarioInicioSesion(email);
                if (resp.Equals("1"))
                {
                    return inicioSesion.CerrarSesion(email);
                }
                else
                {
                    return resp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PersonaModel> obtenerListaFuncionarios()
        {
            try
            {
                return usuario.ObtenerFuncionarios();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
