using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases
{
    public class Pago
    {
        private HorasExtraEntities entities;
        private FormularioPago pagos = new FormularioPago();
        

        public Pago()
        {
            entities = new HorasExtraEntities();

        }

        public string CrearPago(string email, string motivo, PAGOS tarea)
        {
            try
            {
                if (pagos.obternerFormularioPago(email, motivo).Count != 0)
                {
                    try
                    {
                        entities.PAGOS.Add(tarea);
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

        public List<PAGOS> obternerFormularioPago(string email, string motivo)
        {
            try
            {
                int id = pagos.obterneridFormularioPago(email, motivo);

                List<PAGOS> model = new List<PAGOS>();
                var query = from c in entities.PAGOS
                            where c.idFormularioPago == id
                            select c;
                model = query.ToList<PAGOS>();

                return model;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public int obterneridPago(string email, string motivo)
        {
            try
            {
                int id = pagos.obterneridFormularioPago(email, motivo);

                List<PAGOS> model = new List<PAGOS>();
                var query = from c in entities.PAGOS
                            where c.idFormularioPago == id
                            select c;
                model = query.ToList<PAGOS>();

                int id1 = 0;

                foreach(PAGOS t in model)
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

    }
}
