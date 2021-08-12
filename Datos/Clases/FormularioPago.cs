using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
   public class FormularioPago
    {
        private HorasExtraEntities entities;
        private FormularioTiempo tiempo = new FormularioTiempo();
        

        public FormularioPago()
        {
            entities = new HorasExtraEntities();

        }

        public string CrearFormularioPago(string email,string motivo, FORMULARIOS_PAGO tarea)
        {
            try
            {
                if (tiempo.obternerFormularioTiempo(email,motivo).Count !=0)
                {
                    try
                    {
                        entities.SOLICITUD_TAREAS.Add(tarea);
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

        public List<FORMULARIOS_PAGO> obternerFormularioPago(string email,string motivo)
        {
            try
            {
                int id = tiempo.obterneridFormularioTiempo(email,motivo);

                List<FORMULARIOS_PAGO> model = new List<FORMULARIOS_PAGO>();
                var query = from c in entities.FORMULARIOS_PAGO
                            where c.idFormularioTiempo == id
                            select c;
                model = query.ToList<FORMULARIOS_PAGO>();

                return model;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
