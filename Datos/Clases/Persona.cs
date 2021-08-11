using Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    public class Persona
    {

        private HorasExtraEntities entities;
        private Departamento departamento;

        public Persona()
        {
            entities = new HorasExtraEntities();
            departamento = new Departamento();
        }

        public bool ExistePersona(string email)
        {
            try
            {
                var query = from c in entities.PERSONAS
                            where c.Email == email
                            select c;

                List<PERSONAS> user = query.ToList<PERSONAS>();

                if (user.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int getIdPersona(string email)
        {
            try
            {
                var query = from c in entities.PERSONAS
                            where c.Email == email
                            select c;

                List<PERSONAS> user = query.ToList<PERSONAS>();

                foreach (PERSONAS u in user)
                {
                    if (u.Email == email)
                    {
                        return u.idPersona;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public int getIdPersonaNombreJefe(string nombreCompleto)
        //{
        //    try
        //    {
        //        string[] data = nombreCompleto.Split(' ');
        //        string nombre = data[0];
        //        string apellidos = data[1];
        //        var query = from c in entities.PERSONAS
        //                    where c.Nombre == nombre && c.Apellidos == apellidos && c.idDepartamento == 1
        //                    select c;

        //        List<PERSONAS> user = query.ToList<PERSONAS>();

        //        foreach (PERSONAS u in user)
        //        {
        //            if (u.Nombre == data[0] && u.Apellidos == data[1] && u.idDepartamento == 1)
        //            {
        //                return u.idPersona;
        //            }
        //        }

        //        return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        
        //public int getIdJefe(string nombreCompleto)
        //{
        //    try
        //    {
        //        int idPersona = getIdPersonaNombreJefe(nombreCompleto);
        //        var query = from c in entities.JEFATURA
        //                    where c.idPersona == idPersona
        //                    select c;

        //        List<JEFATURA> user = query.ToList<JEFATURA>();

        //        foreach (JEFATURA u in user)
        //        {
        //            if (u.idPersona == idPersona)
        //            {
        //                return u.idJefatura;
        //            }
        //        }

        //        return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private string EncrytarPassword(string password)
        {
            try
            {
                string result = string.Empty;
                byte[] encryted = System.Text.Encoding.Unicode.GetBytes(password);
                result = Convert.ToBase64String(encryted);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int crearPersona(PersonaModel persona)
        {
            try
            {
                PERSONAS p = new PERSONAS()
                {
                    NombreCompleto = persona.nombreCompleto,
                    Email = persona.email,
                    Pass = EncrytarPassword(persona.pass),
                    idDepartamento = departamento.getIdDepartamento(persona.departamento)
                };

                entities.PERSONAS.Add(p);
                return entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PersonaModel BuscarPersona(string email)
        {
            try
            {
                var query = from c in entities.PERSONAS
                            where c.Email == email
                            select c;

                List<PERSONAS> user = query.ToList<PERSONAS>();

                foreach (PERSONAS u in user)
                {
                    if (u.Email == email)
                    {
                        return new PersonaModel()
                        {
                            nombreCompleto = u.NombreCompleto,
                            email = u.Email,
                            departamento = departamento.getNombreDepartamento(u.idDepartamento)
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
    }
}
