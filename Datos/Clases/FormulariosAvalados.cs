using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    public class FormulariosAvalados
    {
        private HorasExtraEntities entities;
        public Tarea persona = new Tarea();

        public FormulariosAvalados()
        {
            entities = new HorasExtraEntities();

        }

        public string CrearFormularioAvalado(string motivo, FORMULARIOS_AVALADOS tarea)
        {
            try
            {
                if (persona.idTarea(motivo)==1)
                {
                    try
                    {
                        entities.FORMULARIOS_AVALADOS.Add(tarea);
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

        public List<FormulariosSolcitudPersona> obternerFormularioAvalados(string email)
        {
            try
            {
                
                    List<FormulariosSolcitudPersona> model = new List<FormulariosSolcitudPersona>();
                    var query = from c in entities.FormulariosSolcitudPersona
                                where c.Email == email
                                select c;
                  model = query.ToList<FormulariosSolcitudPersona>();

                return model;

                    
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
