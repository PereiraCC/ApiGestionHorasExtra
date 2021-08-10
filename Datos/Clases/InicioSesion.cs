//using Datos.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Datos.Clases
//{
//    public class InicioSesion
//    {
//        private devHorasExtraEntities entities;
//        private Ticket ticket;

//        public InicioSesion()
//        {
//            entities = new devHorasExtraEntities();
//            ticket = new Ticket();
//        }

//        private int IdUsuario(string email)
//        {
//            try
//            {
//                var query = from c in entities.PERSONAS
//                            where c.Email == email
//                            select c;
//                List<PERSONAS> user = query.ToList<PERSONAS>();
//                if (user.Count > 0)
//                {
//                    return user[0].idPersona;
//                }
//                else
//                {
//                    return 0;
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        private string DesEncrytarPassword(string password)
//        {
//            try
//            {
//                string result = string.Empty;
//                byte[] dencryted = Convert.FromBase64String(password);
//                result = System.Text.Encoding.Unicode.GetString(dencryted);
//                return result;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        private List<PERSONAS> BuscarUsuario(string email)
//        {
//            try
//            {
//                var query = from c in entities.PERSONAS
//                            where c.Email == email
//                            select c;
//                return query.ToList<PERSONAS>();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public string ValidarInicioSesion(PersonaModel p)
//        {
//            try
//            {
//                List<PERSONAS> usuarios = BuscarUsuario(p.email);

//                if (usuarios.Count > 0)
//                {
//                    foreach (PERSONAS user in usuarios)
//                    {
//                        if (user.Email == p.email && DesEncrytarPassword(user.Pass) == p.pass)
//                        {
//                            string resp = ticket.validarTicket(IdUsuario(p.email));
//                            if (resp.Equals("2") || resp.Equals("1") || resp.Equals("0"))
//                            {
//                                if (ticket.InactivarTiquete(IdUsuario(p.email)))
//                                {
//                                    string clave = ticket.crearTicket(user);
//                                    if (clave.Equals("Error al generar el tiquete"))
//                                    {
//                                        return "0";
//                                    }
//                                    else
//                                    {
//                                        return clave;
//                                    }
//                                }
//                                else
//                                {
//                                    return "Error al generar el tiquete";
//                                }
//                            }
//                            else if (resp.Equals("No tickets"))
//                            {
//                                string clave = ticket.crearTicket(user);
//                                if (clave.Equals("Error al generar el tiquete"))
//                                {
//                                    return "0";
//                                }
//                                else
//                                {
//                                    return clave;
//                                }
//                            }
//                        }
//                    }
//                    return "0";
//                }
//                else
//                {
//                    return "El usuario no existe";
//                }

//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public string CerrarSesion(string email)
//        {
//            try
//            {
//                List<PERSONAS> usuarios = BuscarUsuario(email);

//                if (usuarios.Count > 0)
//                {

//                    if (ticket.InactivarTicketCierreSesion(IdUsuario(email)))
//                    {
//                        return "1";
//                    }
//                    else
//                    {
//                        return "0";
//                    }
//                }
//                else
//                {
//                    return "El usuario no existe";
//                }

//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

     

//    }
//}
