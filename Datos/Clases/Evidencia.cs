using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    public class Evidencia
    {
        private HorasExtraEntities entities;
        public Tarea persona = new Tarea();

        public Evidencia()
        {
            entities = new HorasExtraEntities();

        }

        public string CrearEvidencia(string motivo, EVIDENCIAS tarea)
        {
            try
            {
                if (persona.idTarea(motivo)!=0)
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
                else
                {
                    return "Persona no existe";

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<EVIDENCIAS> obternerFormularioEvidencia(string email)
        {
            try
            {
                int id=persona.idTarea(email);

                List<EVIDENCIAS> model = new List<EVIDENCIAS>();
                var query = from c in entities.EVIDENCIAS
                            where c.idSolicitud == id
                            select c;
                model = query.ToList<EVIDENCIAS>();

                return model;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
