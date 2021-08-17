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

        public string CrearPago(PAGOS pago)
        {
            try
            {
                //if (pagos.obternerFormularioPago(email, motivo).Count != 0)
                //{
                    try
                    {
                        entities.PAGOS.Add(pago);
                        int res = entities.SaveChanges();
                        if (res == 1)
                        {
                            return pagos.ActualizarFormularioAvalado(pago.idFormularioPago);
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


        public int obternerIdTipoPago(string nombre)
        {
            try
            {
                List<TIPOSPAGO> model = new List<TIPOSPAGO>();
                var query = from c in entities.TIPOSPAGO
                            where c.Descripcion == nombre
                            select c;
                model = query.ToList<TIPOSPAGO>();

                foreach(TIPOSPAGO t in model)
                {
                    if (t.Descripcion.Equals(nombre))
                    {
                        return t.idTipoPago;
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
