//using Datos.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Text;
//using System.Threading.Tasks;

//namespace Datos.Clases
//{
//    public class Ticket
//    {
//        private HorasExtraEntities entities;

//        public Ticket()
//        {
//            entities = new HorasExtraEntities();
//        }

//        private int CantidadMinutos()
//        {
//            try
//            {
//                var temp = from l in entities.CONFIGURACIONTOKEN
//                           select l;
//                List<CONFIGURACIONTOKEN> t = temp.ToList<CONFIGURACIONTOKEN>();

//                return t[0].Tiempo;

//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public bool RefrescarTiquete(int usuario)
//        {
//            try
//            {
//                TICKETS ticket = obtenerTicket(usuario);

//                TICKETS nuevo = ticket;
//                nuevo.HoraFinal = nuevo.HoraFinal.AddMinutes(CantidadMinutos());
//                int n = entities.SaveChanges();
//                if (n > 0)
//                {
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }
//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//        }

//        public bool InactivarTiquete(int usuario)
//        {
//            try
//            {
//                TICKETS ticket = obtenerTicket(usuario);

//                if (ticket.Fecha < DateTime.Now)
//                {
//                    TICKETS nuevo = ticket;
//                    nuevo.Estado = false;
//                    int n = entities.SaveChanges();
//                    if (n > 0)
//                    {
//                        return true;
//                    }
//                    else
//                    {
//                        return false;
//                    }
//                }
//                else
//                {
//                    DateTime horaActual = DateTime.Now.ToLocalTime();
//                    if (ticket.HoraInicio < horaActual && ticket.HoraFinal > horaActual)
//                    {
//                        TICKETS nuevo = ticket;
//                        nuevo.Estado = false;
//                        int n = entities.SaveChanges();
//                        if (n > 0)
//                        {
//                            return true;
//                        }
//                        else
//                        {
//                            return false;
//                        }
//                    }
//                    else
//                    {
//                        return false;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public string GetMD5(string str)
//        {
//            try
//            {
//                MD5 md5 = MD5CryptoServiceProvider.Create();
//                ASCIIEncoding encoding = new ASCIIEncoding();
//                byte[] stream = null;
//                StringBuilder sb = new StringBuilder();
//                stream = md5.ComputeHash(encoding.GetBytes(str));
//                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
//                return sb.ToString();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public string crearTicket(PERSONAS p)
//        {
//            try
//            {
//                string clave = GetMD5(p.idPersona + p.DocumentoIdentificacion + p.Nombre + p.Apellidos + DateTime.Now.Date + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second);
//                TICKETS tiquete = new TICKETS();
//                tiquete.Estado = true;
//                tiquete.Fecha = DateTime.Now.Date;
//                tiquete.HoraInicio = DateTime.Now.ToLocalTime();
//                tiquete.Ticket = clave;
//                tiquete.idPersona = p.idPersona;
//                tiquete.HoraFinal = tiquete.HoraInicio.AddMinutes(CantidadMinutos());
//                entities.TICKETS.Add(tiquete);

//                int res = entities.SaveChanges();
//                if (res != 0)
//                {
//                    return clave;
//                }
//                else
//                {
//                    return "Error al generar el tiquete";
//                }

//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }

//        }

//        public bool InactivarTicketCierreSesion(int usuario)
//        {
//            try
//            {
//                TICKETS ticket = obtenerTicket(usuario);

//                TICKETS nuevo = ticket;
//                nuevo.Estado = false;
//                int n = entities.SaveChanges();
//                if (n > 0)
//                {
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }

//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public string validarTicket(int idPersona)
//        {
//            try
//            {
//                DateTime horaActual = DateTime.Now.ToLocalTime();
//                var temp = from l in entities.TICKETS
//                           where l.idPersona == idPersona && l.Estado == true
//                           select l;

//                List<TICKETS> t = temp.ToList<TICKETS>();

//                if (t.Count > 0)
//                {
//                    if (t[0].HoraInicio < horaActual && t[0].HoraFinal > horaActual)
//                    {
//                        return "1";
//                    }
//                    else if (t[0].HoraInicio < horaActual && t[0].HoraFinal < horaActual)
//                    {
//                        return "2";
//                    }
//                    else
//                    {
//                        return "0";
//                    }
//                }
//                else
//                {
//                    return "No tickets";
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        public string GetTicket(int idPersona)
//        {
//            try
//            {
//                string validar = validarTicket(idPersona);

//                if (validar.Equals("1"))
//                {
//                    var temp = from l in entities.TICKETS
//                               where l.idPersona == idPersona && l.Estado == true
//                               select l;

//                    List<TICKETS> t = temp.ToList<TICKETS>();

//                    return t[0].Ticket;
//                }
//                else if (validar.Equals("2"))
//                {
//                    if (RefrescarTiquete(idPersona))
//                    {
//                        var temp = from l in entities.TICKETS
//                                   where l.idPersona == idPersona && l.Estado == true
//                                   select l;

//                        List<TICKETS> t = temp.ToList<TICKETS>();

//                        return t[0].Ticket;
//                    }
//                    else
//                    {
//                        return "0";
//                    }
//                }
//                else
//                {
//                    return "0";
//                }
//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//        }

//        public TICKETS obtenerTicket(int idPersona)
//        {
//            try
//            {
//                var temp = from l in entities.TICKETS
//                           where l.idPersona == idPersona && l.Estado == true
//                           select l;

//                List<TICKETS> t = temp.ToList<TICKETS>();

//                return t[0];
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }

//        }


//    }
//}
