using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    public class InicioSesion
    {
        private HorasExtraEntities entities;

        public InicioSesion()
        {
            entities = new HorasExtraEntities();
        }

        private int IdUsuario(string email)
        {
            try
            {
                var query = from c in entities.PERSONAS
                            where c.Email == email
                            select c;
                List<PERSONAS> user = query.ToList<PERSONAS>();
                if (user.Count > 0)
                {
                    return user[0].idPersona;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string DesEncrytarPassword(string password)
        {
            try
            {
                string result = string.Empty;
                byte[] dencryted = Convert.FromBase64String(password);
                result = System.Text.Encoding.Unicode.GetString(dencryted);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<PERSONAS> BuscarUsuario(string email)
        {
            try
            {
                var query = from c in entities.PERSONAS
                            where c.Email == email
                            select c;
                return query.ToList<PERSONAS>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ValidarInicioSesion(PersonaModel p)
        {
            try
            {
                List<PERSONAS> usuarios = BuscarUsuario(p.email);

                if (usuarios.Count > 0)
                {
                    foreach (PERSONAS user in usuarios)
                    {
                        if (user.Email == p.email && DesEncrytarPassword(user.Pass) == p.pass)
                        {
                            return "1";
                        }
                    }
                    return "Datos incorrectos";
                }
                else
                {
                    return "El usuario no existe";
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
                List<PERSONAS> usuarios = BuscarUsuario(email);

                if (usuarios.Count > 0)
                {
                     return "1";
                }
                else
                {
                    return "El usuario no existe";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
