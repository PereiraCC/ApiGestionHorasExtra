using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    public class Evidencia
    {
        private HorasExtraEntities entities;
        public Persona persona = new Persona();

        public Evidencia()
        {
            entities = new HorasExtraEntities();

        }

        public string CrearEvidencia(EVIDENCIAS tarea)
        {
            try
            {
                entities.EVIDENCIAS.Add(tarea);
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

        public List<EvidenciasFuncionario> obternerEvidenciasFuncionario(string email)
        {
            try
            {
                int id = persona.getIdPersona(email);

                var query = from c in entities.EvidenciasFuncionario
                            where c.idPersona == id && c.Estado == false
                            select c;
                return query.ToList<EvidenciasFuncionario>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string aceptarEvidencia(int idEvidencia)
        {

            try
            {
                EVIDENCIAS e = entities.EVIDENCIAS.First<EVIDENCIAS>(x => x.idEvidencia == idEvidencia);
                e.Estado = true;

                entities.Entry(e).State = EntityState.Modified;

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
