using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public string CrearFormularioPago(FORMULARIOS_PAGO formulario)
        {
            try
            {
                //if (tiempo.obternerFormularioTiempo(email,motivo).Count !=0)
                //{
                    try
                    {
                        entities.FORMULARIOS_PAGO.Add(formulario);
                        int res = entities.SaveChanges();
                        if (res == 1)
                        {
                            return tiempo.ActualizarFormularioTiempo(formulario.idFormularioTiempo);
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

                //}
                //else
                //{
                //    return "Persona no existe";

                //}

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<ObtenerFormularioPago> obternerFormularioPago(string email)
        {
            try
            {
                //int id = tiempo.obterneridFormularioTiempo(email,motivo);

                List<ObtenerFormularioPago> model = new List<ObtenerFormularioPago>();
                var query = from c in entities.ObtenerFormularioPago
                            where c.Email == email
                            select c;
                model = query.ToList<ObtenerFormularioPago>();

                return model;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int obterneridFormularioPago(string email, string motivo)
        {
            try
            {
                int id = tiempo.obterneridFormularioTiempo(email, motivo);

                List<FORMULARIOS_PAGO> model = new List<FORMULARIOS_PAGO>();
                var query = from c in entities.FORMULARIOS_PAGO
                            where c.idFormularioTiempo == id
                            select c;
                model = query.ToList<FORMULARIOS_PAGO>();
                int id1 = 0;
                foreach(FORMULARIOS_PAGO t in model)
                {
                    id1 = t.idFormularioPago;
                }

                return id1;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string ActualizarFormularioAvalado(int idFormularioPago)
        {

            try
            {
                FORMULARIOS_PAGO f = entities.FORMULARIOS_PAGO.First<FORMULARIOS_PAGO>(x => x.idFormularioPago == idFormularioPago);
                f.Estado = true;

                entities.Entry(f).State = EntityState.Modified;

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
